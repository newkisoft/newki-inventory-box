using System.Collections.Generic;
using System.Linq;
using newkilibraries;
using Microsoft.Extensions.Configuration;
using newki_inventory_box.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Net.Http;
using System.Text;
using Amazon;
using System;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading;

namespace newki_inventory_box
{
    class Program
    {
        static ManualResetEvent _quitEvent = new ManualResetEvent(false);
        private static ServiceProvider serviceProvider;
        private static string _connectionString;

        static void Main(string[] args)
        {

            //Reading configuration
            var Boxs = new List<Box>();
            var awsStorageConfig = new AwsStorageConfig();
            var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true);
            var Configuration = builder.Build();

            Configuration.GetSection("AwsStorageConfig").Bind(awsStorageConfig);
            _connectionString = Configuration.GetConnectionString("DefaultConnection");

            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAwsService, AwsService>();
            services.AddTransient<IBoxService, BoxService>();
            services.AddSingleton<IAwsStorageConfig>(awsStorageConfig);

            serviceProvider = services.BuildServiceProvider();


            var requestQueueName = "BoxRequest";
            var responseQueueName = "BoxResponse";

            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "user";
            factory.Password = "password";
            factory.HostName = "localhost";

            var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.QueueDeclare(requestQueueName, false, false, false);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                var updateBoxFullNameModel = JsonSerializer.Deserialize<InventoryMessage>(content);

                ProcessRequest(updateBoxFullNameModel);

            };
            channel.BasicConsume(queue: requestQueueName,
                   autoAck: true,
                   consumer: consumer);


            _quitEvent.WaitOne();

        }

        private static void ProcessRequest(InventoryMessage inventoryMessage)
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseNpgsql(_connectionString);

                using (var appDbContext = new ApplicationDbContext(optionsBuilder.Options))
                {
                    var boxService = new BoxService(appDbContext);
                    var messageType = Enum.Parse<InventoryMessageType>(inventoryMessage.Command);

                    switch (messageType)
                    {
                        case InventoryMessageType.Search:
                            {
                                Console.WriteLine("Loading all the Boxes...");
                                var Boxes = appDbContext.Box.OrderByDescending(p => p.BoxId).ToList();

                                foreach (var Box in Boxes)
                                {
                                    var existingBox = appDbContext.BoxDataView.Find(Box.BoxId);
                                    if (existingBox != null)
                                    {
                                        existingBox.Data = JsonSerializer.Serialize(Box);
                                    }
                                    else
                                    {
                                        var BoxDataView = new BoxDataView
                                        {
                                            BoxId = Box.BoxId,
                                            Data = JsonSerializer.Serialize(Box)
                                        };
                                        appDbContext.BoxDataView.Add(BoxDataView);
                                    }
                                }
                                appDbContext.SaveChanges();
                                boxService.UpdateFilters();
                                break;
                            }
                        case InventoryMessageType.Get:
                            {
                                Console.WriteLine("Loading a Box...");
                                var id = JsonSerializer.Deserialize<int>(inventoryMessage.Message);
                                var Box = boxService.GetBox(id);
                                var content = JsonSerializer.Serialize(Box);

                                var responseMessageNotification = new InventoryMessage();
                                responseMessageNotification.Command = InventoryMessageType.Get.ToString();
                                responseMessageNotification.RequestNumber = inventoryMessage.RequestNumber;
                                responseMessageNotification.Message = content;
                                responseMessageNotification.MessageDate = DateTimeOffset.UtcNow;

                                Console.WriteLine("Sending the message back");

                                break;

                            }
                        case InventoryMessageType.Insert:
                            {
                                Console.WriteLine("Adding new Box");
                                var Box = JsonSerializer.Deserialize<Box>(inventoryMessage.Message);
                                boxService.Insert(Box);
                                var BoxDataView = new BoxDataView
                                {
                                    BoxId = Box.BoxId,
                                    Data = JsonSerializer.Serialize(Box)
                                };
                                appDbContext.BoxDataView.Add(BoxDataView);
                                appDbContext.SaveChanges();

                                break;
                            }
                        case InventoryMessageType.Update:
                            {
                                Console.WriteLine("Updating a Box");
                                var Box = JsonSerializer.Deserialize<Box>(inventoryMessage.Message);
                                boxService.Update(Box);
                                var existingBox = appDbContext.BoxDataView.Find(Box.BoxId);
                                existingBox.Data = JsonSerializer.Serialize(Box);
                                appDbContext.SaveChanges();
                                break;
                            }
                        case InventoryMessageType.Delete:
                            {
                                Console.WriteLine("Deleting a Box");
                                var id = JsonSerializer.Deserialize<int>(inventoryMessage.Message);
                                boxService.Remove(id);
                                var removeBox = appDbContext.BoxDataView.FirstOrDefault(predicate => predicate.BoxId == id);
                                appDbContext.BoxDataView.Remove(removeBox);
                                appDbContext.SaveChanges();
                                break;
                            }
                        default: break;

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
