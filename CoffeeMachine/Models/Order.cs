using System;

namespace CoffeeMachine.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string CoffeeName { get; set; }

        public DateTime OrderTime { get; set; }
    }
}