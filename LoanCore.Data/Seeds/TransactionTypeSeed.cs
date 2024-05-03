using LoanCore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LoanCore.Data.Seeds
{
    public static class TransactionTypeSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType
                {
                    Id = Guid.NewGuid(),
                    Name = "Payment",
                    Description = "Liquidación total del préstamo"
                },
                new TransactionType
                {
                    Id = Guid.NewGuid(),
                    Name = "Interest",
                    Description = "Pago del interés generado por el préstamo"
                },
                new TransactionType
                {
                    Id = Guid.NewGuid(),
                    Name = "Discount",
                    Description = "Descuento al interés del préstamo"
                },
                new TransactionType
                {
                    Id = Guid.NewGuid(),
                    Name = "PartialPay",
                    Description = "Abono al capital"
                }
            );
        }
    }
}
