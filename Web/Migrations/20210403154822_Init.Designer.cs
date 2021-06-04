﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web;

namespace Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210403154822_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("newkilibraries.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Vergi")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("AgentId");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("newkilibraries.AgentCustomer", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("AgentId")
                        .HasColumnType("integer");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision");

                    b.HasKey("CustomerId", "AgentId");

                    b.HasIndex("AgentId");

                    b.ToTable("AgentCustomer");
                });

            modelBuilder.Entity("newkilibraries.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("newkilibraries.Box", b =>
                {
                    b.Property<int>("BoxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<string>("BobbinSize")
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("ColorCode")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Denier")
                        .HasColumnType("integer");

                    b.Property<int>("Filament")
                        .HasColumnType("integer");

                    b.Property<string>("Intermingle")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("boolean");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("PalletId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("RemainWeight")
                        .HasColumnType("double precision");

                    b.Property<bool>("Sold")
                        .HasColumnType("boolean");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<string>("YarnType")
                        .HasColumnType("text");

                    b.HasKey("BoxId");

                    b.HasIndex("PalletId");

                    b.ToTable("Box");
                });

            modelBuilder.Entity("newkilibraries.BoxDataView", b =>
                {
                    b.Property<int>("BoxId")
                        .HasColumnType("integer");

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.HasKey("BoxId");

                    b.ToTable("BoxDataView");
                });

            modelBuilder.Entity("newkilibraries.BoxFilter", b =>
                {
                    b.Property<int>("BoxFilterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ColumnName")
                        .HasColumnType("text");

                    b.Property<string>("Keywords")
                        .HasColumnType("text");

                    b.HasKey("BoxFilterId");

                    b.ToTable("BoxFilter");
                });

            modelBuilder.Entity("newkilibraries.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Gmail")
                        .HasColumnType("text");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int>("Rate")
                        .HasColumnType("integer");

                    b.Property<string>("Vergi")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.Property<string>("ZipCode")
                        .HasColumnType("text");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("newkilibraries.DocumentFile", b =>
                {
                    b.Property<int>("DocumentFileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FileName")
                        .HasColumnType("text");

                    b.HasKey("DocumentFileId");

                    b.ToTable("DocumentFile");
                });

            modelBuilder.Entity("newkilibraries.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Currency")
                        .HasColumnType("text");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<string>("DriverName")
                        .HasColumnType("text");

                    b.Property<string>("DriverRegistrationNumber")
                        .HasColumnType("text");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("double precision");

                    b.Property<bool>("HasOfficialInvoice")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("InvoiceDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("InvoiceDueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Kdv")
                        .HasColumnType("double precision");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<double>("Paid")
                        .HasColumnType("double precision");

                    b.Property<int>("StateInvoiceNumber")
                        .HasColumnType("integer");

                    b.Property<double>("Tax")
                        .HasColumnType("double precision");

                    b.Property<double>("TotalUsd")
                        .HasColumnType("double precision");

                    b.HasKey("InvoiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("newkilibraries.InvoiceBox", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("BoxId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("InvoiceId", "BoxId");

                    b.HasIndex("BoxId");

                    b.ToTable("InvoiceBox");
                });

            modelBuilder.Entity("newkilibraries.InvoiceDocumentFile", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("DocumentFileId")
                        .HasColumnType("integer");

                    b.HasKey("InvoiceId", "DocumentFileId");

                    b.HasIndex("DocumentFileId");

                    b.ToTable("InvoiceDocumentFile");
                });

            modelBuilder.Entity("newkilibraries.InvoicePallet", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<int>("PalletId")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("InvoiceId", "PalletId");

                    b.HasIndex("PalletId");

                    b.ToTable("InvoicePallet");
                });

            modelBuilder.Entity("newkilibraries.InvoicePayment", b =>
                {
                    b.Property<int>("InvoicePaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<double>("ExchangeRate")
                        .HasColumnType("double precision");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("InvoicePaymentId");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoicePayment");
                });

            modelBuilder.Entity("newkilibraries.Pallet", b =>
                {
                    b.Property<int>("PalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<string>("BobbinSize")
                        .HasColumnType("text");

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<string>("ColorCode")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("DeliveryDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Denier")
                        .HasColumnType("integer");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<int>("Filament")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.Property<string>("Intermingle")
                        .HasColumnType("text");

                    b.Property<bool>("IsDelivered")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsOnlineProduct")
                        .HasColumnType("boolean");

                    b.Property<string>("Lot")
                        .HasColumnType("text");

                    b.Property<string>("Lustre")
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("integer");

                    b.Property<string>("PalletName")
                        .HasColumnType("text");

                    b.Property<string>("PalletNumber")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<double>("RemainWeight")
                        .HasColumnType("double precision");

                    b.Property<int>("RemainingItems")
                        .HasColumnType("integer");

                    b.Property<bool>("Sold")
                        .HasColumnType("boolean");

                    b.Property<string>("ThumbnailImage")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<string>("Warehouse")
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.Property<string>("YarnType")
                        .HasColumnType("text");

                    b.HasKey("PalletId");

                    b.ToTable("Pallet");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("newkilibraries.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("newkilibraries.AgentCustomer", b =>
                {
                    b.HasOne("newkilibraries.Agent", "Agent")
                        .WithMany("Customers")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.Customer", "Customer")
                        .WithMany("Agents")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("newkilibraries.Box", b =>
                {
                    b.HasOne("newkilibraries.Pallet", "Pallet")
                        .WithMany()
                        .HasForeignKey("PalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pallet");
                });

            modelBuilder.Entity("newkilibraries.Invoice", b =>
                {
                    b.HasOne("newkilibraries.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("newkilibraries.InvoiceBox", b =>
                {
                    b.HasOne("newkilibraries.Box", "Box")
                        .WithMany("InvoiceBoxess")
                        .HasForeignKey("BoxId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.Invoice", "Invoice")
                        .WithMany("InvoiceBoxes")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Box");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("newkilibraries.InvoiceDocumentFile", b =>
                {
                    b.HasOne("newkilibraries.DocumentFile", "File")
                        .WithMany()
                        .HasForeignKey("DocumentFileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.Invoice", "Invoice")
                        .WithMany("Files")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("File");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("newkilibraries.InvoicePallet", b =>
                {
                    b.HasOne("newkilibraries.Invoice", "Invoice")
                        .WithMany("InvoicePallets")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("newkilibraries.Pallet", "Pallet")
                        .WithMany("InvoicePallets")
                        .HasForeignKey("PalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Pallet");
                });

            modelBuilder.Entity("newkilibraries.InvoicePayment", b =>
                {
                    b.HasOne("newkilibraries.Invoice", null)
                        .WithMany("Payments")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("newkilibraries.Agent", b =>
                {
                    b.Navigation("Customers");
                });

            modelBuilder.Entity("newkilibraries.Box", b =>
                {
                    b.Navigation("InvoiceBoxess");
                });

            modelBuilder.Entity("newkilibraries.Customer", b =>
                {
                    b.Navigation("Agents");
                });

            modelBuilder.Entity("newkilibraries.Invoice", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("InvoiceBoxes");

                    b.Navigation("InvoicePallets");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("newkilibraries.Pallet", b =>
                {
                    b.Navigation("InvoicePallets");
                });
#pragma warning restore 612, 618
        }
    }
}
