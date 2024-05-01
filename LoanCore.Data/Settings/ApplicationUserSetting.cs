using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LoanCore.Data.Settings
{
    public class ApplicationUserSetting : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(p => p.FirstName).HasMaxLength(128).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(128).IsRequired();
        }
    }
}