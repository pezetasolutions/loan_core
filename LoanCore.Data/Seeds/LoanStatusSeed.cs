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
                    Id = new Guid("5c94273a-2811-42a7-b766-4895b71d6ee6"),
                    Name = "Active",
                    Description = "Préstamo activo",
                    CreatedAt = DateTime.UtcNow
                },
                new LoanStatus
                {
                    Id = new Guid("0ee833d0-4ec8-4804-8bc1-55fd37312933"),
                    Name = "Paid",
                    Description = "Préstamo liquidado",
                    CreatedAt = DateTime.UtcNow
                },
                new LoanStatus
                {
                    Id = new Guid("aef261a4-1e4a-41a8-84af-7ccf2baafe1f"),
                    Name = "Late",
                    Description = "Préstamo activo con mensualidad atrasada",
                    CreatedAt = DateTime.UtcNow
                });
        }
    }
}