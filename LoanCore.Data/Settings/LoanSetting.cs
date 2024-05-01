using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanCore.Data.Settings
{
    public class LoanSetting : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(p => p.CustomerId).IsRequired();
            builder.Property(p => p.Total).IsRequired();
            builder.Property(p => p.MonthlyInterest).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}