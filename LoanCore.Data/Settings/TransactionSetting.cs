using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanCore.Data.Settings
{
    public class TransactionSetting : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(p => p.Amount).IsRequired();
            builder.Property(p => p.LoanId).IsRequired();
            builder.Property(p => p.TypeId).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}