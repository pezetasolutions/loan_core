using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanCore.Data.Settings
{
    public class LoanStatusSetting : IEntityTypeConfiguration<LoanStatus>
    {
        public void Configure(EntityTypeBuilder<LoanStatus> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(256);
            builder.Property(p => p.CreatedAt).IsRequired();
        }
    }
}