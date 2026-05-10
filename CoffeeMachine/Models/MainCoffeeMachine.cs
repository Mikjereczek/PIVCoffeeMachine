using System.Collections.Generic;

namespace CoffeeMachine.Models
{
    public class MainCoffeeMachine
    {
        public int Water { get; private set; } = 1000;
        public int CoffeeBeans { get; private set; } = 500;
        public int Milk { get; private set; } = 500;

        private readonly Dictionary<CoffeeType, CoffeeRecipe> _recipes;

        public MainCoffeeMachine()
        {
            _recipes = new Dictionary<CoffeeType, CoffeeRecipe>
            {
                {
                    CoffeeType.Espresso,
                    new CoffeeRecipe
                    {
                        Water = 50,
                        CoffeeBeans = 10,
                        Milk = 0
                    }
                },

                {
                    CoffeeType.Cappuccino,
                    new CoffeeRecipe
                    {
                        Water = 50,
                        CoffeeBeans = 10,
                        Milk = 50
                    }
                },

                {
                    CoffeeType.Latte,
                    new CoffeeRecipe
                    {
                        Water = 50,
                        CoffeeBeans = 10,
                        Milk = 100
                    }
                }
            };
        }

        public string MakeCoffee(CoffeeType type)
        {
            var recipe = _recipes[type];

            if (Water < recipe.Water)
                return "Brak wody!";

            if (CoffeeBeans < recipe.CoffeeBeans)
                return "Brak kawy!";

            if (Milk < recipe.Milk)
                return "Brak mleka!";

            Water -= recipe.Water;
            CoffeeBeans -= recipe.CoffeeBeans;
            Milk -= recipe.Milk;

            return $"{type} gotowe!";
        }

        public void Refill()
        {
            Water = 1000;
            CoffeeBeans = 500;
            Milk = 500;
        }
    }
}