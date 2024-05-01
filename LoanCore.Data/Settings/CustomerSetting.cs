using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCore.Data.Settings
{
    public class CustomerSetting : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(128).IsRequired();
            builder.Property(p => p.PhoneNumber).HasMaxLength(16).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(512).IsRequired();
        }
    }
}