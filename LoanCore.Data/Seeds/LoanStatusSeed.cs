using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanCore.Data.Seeds
{
    public static class LoanStatusSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoanStatus>().HasData(
                new LoanStatus
                {
                    Id = Guid.NewGuid(),
                    Name = "Active",
                    Description = "Préstamo activo",
                    CreatedAt = DateTime.UtcNow
                },
                new LoanStatus
                {
                    Id = Guid.NewGuid(),
                    Name = "Paid",
                    Description = "Préstamo liquidado",
                    CreatedAt = DateTime.UtcNow
                },
                new LoanStatus
                {
                    Id = Guid.NewGuid(),
                    Name = "Late",
                    Description = "Préstamo activo con mensualidad atrasada",
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}