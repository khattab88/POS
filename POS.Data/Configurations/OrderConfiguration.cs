using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations
{
    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(o => o.OrderDate)
                .IsRequired();

            //HasRequired(o => o.Employee)
            //    .WithMany(e => e.Orders)
            //    .HasForeignKey(o => o.EmployeeId)
            //    .WillCascadeOnDelete(false);

            HasRequired(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .WillCascadeOnDelete(false);
        }
    }
}
