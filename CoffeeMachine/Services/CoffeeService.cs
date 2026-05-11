using CoffeeMachine.Data;
using CoffeeMachine.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoffeeMachine.Services
{
    public class CoffeeService
    {
        public async Task SimulateBrewing()
        {
            await Task.Delay(3000);
        }

        public void SaveOrder(Order order)
        {
            using var db = new AppDbContext();

            db.Orders.Add(order);

            db.SaveChanges();
        }
        
        public async Task<List<Order>> GetOrdersAsync()
        {
            using var db = new AppDbContext();

            return await db.Orders.ToListAsync();
        }
    }
}
