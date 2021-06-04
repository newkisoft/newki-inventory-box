using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using newkilibraries;

namespace Web
{
     public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           builder.Entity<AgentCustomer>().HasKey(sc => new { sc.CustomerId, sc.AgentId });
           builder.Entity<InvoiceBox>().HasKey(sc => new { sc.InvoiceId, sc.BoxId });
           builder.Entity<InvoiceDocumentFile>().HasKey(sc => new { sc.InvoiceId, sc.DocumentFileId });
           builder.Entity<InvoicePallet>().HasKey(sc => new { sc.InvoiceId, sc.PalletId });
            builder.Entity<BoxDataView>().HasKey(sc => new { sc.BoxId });            
            builder.Entity<Box>().HasKey(sc => new { sc.BoxId });            
            builder.Entity<BoxFilter>().HasKey(sc => new { sc.BoxFilterId });            
        }
      
        public DbSet<BoxDataView> BoxDataView{get;set;}
        public DbSet<Box> Box{get;set;}
        public DbSet<BoxFilter> BoxFilter{get;set;}
        
    }
}
