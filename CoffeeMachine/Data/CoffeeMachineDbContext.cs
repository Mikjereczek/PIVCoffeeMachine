using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeMachine.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;
                  Database=CoffeeMachineDB;
                  Trusted_Connection=True;");
        }
    }
}