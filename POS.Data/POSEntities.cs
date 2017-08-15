using Microsoft.AspNet.Identity.EntityFramework;
using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using POS.Data.Configurations;

namespace POS.Data
{
    public class POSEntities : IdentityDbContext<ApplicationUser>
    {
        public POSEntities()
            : base("POSEntities")
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }

        public virtual void Commit() 
        {
            base.SaveChanges();
        }

        public static POSEntities Create() 
        {
            return new POSEntities();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderItemConfiguration());
            modelBuilder.Configurations.Add(new CategoryConfiguration());
        }
    }
}
