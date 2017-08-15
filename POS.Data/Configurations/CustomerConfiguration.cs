﻿using POS.Domain.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(a => a.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
