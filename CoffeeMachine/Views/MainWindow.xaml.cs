using System.Windows;
using CoffeeMachine.ViewModels;

namespace CoffeeMachine
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}