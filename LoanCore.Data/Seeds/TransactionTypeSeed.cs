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
                    Id = new Guid("7a121aa4-a054-4217-938e-5855a429063a"),
                    Name = "Payment",
                    Description = "Liquidación total del préstamo"
                },
                new TransactionType
                {
                    Id = new Guid("081497aa-95c9-4ae6-a6fe-645310396f34"),
                    Name = "Interest",
                    Description = "Pago del interés generado por el préstamo"
                },
                new TransactionType
                {
                    Id = new Guid("d83ad69b-dfe6-4291-9433-8c517311d734"),
                    Name = "InterestToChangeDay",
                    Description = "Pago del interés correspondiente para cambiar fecha de pago"
                },
                new TransactionType
                {
                    Id = new Guid("581abd47-fa1a-4040-acc4-936de4aecde7"),
                    Name = "Discount",
                    Description = "Descuento al interés del préstamo"
                },
                new TransactionType
                {
                    Id = new Guid("9888c9c4-b41d-4e62-8773-753c397c8c77"),
                    Name = "PartialPay",
                    Description = "Abono al capital"
                }
            );
        }
    }
}