using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanCore.Data.Settings
{
    public class TransactionTypeSetting : IEntityTypeConfiguration<TransactionType>
    {
        public void Configure(EntityTypeBuilder<TransactionType> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(32);
            builder.Property(p => p.Description).HasMaxLength(512);
        }
    }
}