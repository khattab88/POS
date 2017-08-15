using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.Price)
                .IsRequired();
                //.HasPrecision(5, 2);

            Property(a => a.ImageUrl)
                .HasMaxLength(250);

            HasRequired(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
