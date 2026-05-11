using CoffeeMachine.Models;
using CoffeeMachine.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoffeeMachine.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly MainCoffeeMachine _machine;
        private readonly CoffeeService _coffeeService;

        public ObservableCollection<Order> Orders { get; set; }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged();
            }
        }

        private bool _isBrewing;
        public bool IsBrewing
        {
            get => _isBrewing;
            set
            {
                _isBrewing = value;
                OnPropertyChanged();
            }
        }

        public int Water => _machine.Water;
        public int CoffeeBeans => _machine.CoffeeBeans;
        public int Milk => _machine.Milk;

        public ICommand EspressoCommand { get; }
        public ICommand CappuccinoCommand { get; }
        public ICommand LatteCommand { get; }
        public ICommand RefillCommand { get; }

        public MainViewModel()
        {
            _machine = new MainCoffeeMachine();
            _coffeeService = new CoffeeService();

            Orders = new ObservableCollection<Order>();

            Status = "Wybierz kawę";

            EspressoCommand =
                new RelayCommand(async () => await MakeCoffee(CoffeeType.Espresso));

            CappuccinoCommand =
                new RelayCommand(async () => await MakeCoffee(CoffeeType.Cappuccino));

            LatteCommand =
                new RelayCommand(async () => await MakeCoffee(CoffeeType.Latte));

            RefillCommand =
                new RelayCommand(RefillMachine);

            LoadOrders();
        }

        private async Task MakeCoffee(CoffeeType type)
        {
            IsBrewing = true;
            Status = "Przygotowywanie kawy...";

            await _coffeeService.SimulateBrewing();

            string result = _machine.MakeCoffee(type);

            Status = result;

            var order = new Order
            {
                CoffeeName = type.ToString(),
                OrderTime = System.DateTime.Now
            };

            Orders.Add(order);

            _coffeeService.SaveOrder(order);

            OnPropertyChanged(nameof(Water));
            OnPropertyChanged(nameof(CoffeeBeans));
            OnPropertyChanged(nameof(Milk));

            IsBrewing = false;
        }

        private void RefillMachine()
        {
            _machine.Refill();

            Status = "Zbiorniki uzupełnione";

            OnPropertyChanged(nameof(Water));
            OnPropertyChanged(nameof(CoffeeBeans));
            OnPropertyChanged(nameof(Milk));
        }
        
        private async void LoadOrders()
        {
            var orders = await _coffeeService.GetOrdersAsync();

            Orders.Clear();

            foreach (var order in orders.OrderByDescending(o => o.OrderTime))
            {
                Orders.Add(order);
            }
        }
    }
}
