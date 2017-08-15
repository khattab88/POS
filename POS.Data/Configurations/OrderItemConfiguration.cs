using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations
{
    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            Property(i => i.Quantity)
                .IsRequired();

            HasRequired(i => i.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(i => i.OrderId)
                .WillCascadeOnDelete(false);

            HasRequired(i => i.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(i => i.ProductId)
                .WillCascadeOnDelete(false);
        }
    }
}
