using CoffeeMachine.Data;
using CoffeeMachine.Models;
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
    }
}