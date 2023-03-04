using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data.Configuration;
using WebsiteData.Entities;

namespace WebsiteData.Data.Context
{
    public class WebsiteDbContext : IdentityDbContext<Account, Function, int>
    {
        public WebsiteDbContext( DbContextOptions<WebsiteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable(name: "Account");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.ToTable(name: "Function");
            });

            modelBuilder.Entity<Permission>()
                .HasKey(c => new { c.FunctionId, c.AccountId });

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());


        }
        
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Function> Functions { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
    }
}
