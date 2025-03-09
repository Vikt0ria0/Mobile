using Microsoft.Maui.Controls;
using Mobile.ViewModels;
using Mobile.Handlers;

namespace Mobile.Views
{
    public partial class MainGoalsPage : ContentPage
    {
        public MainGoalsPage(MainGoalsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            
            // Инициализация обработчика свайпов
            _ = new SwipeGestureHandler(MainGrid, previousRoute: "//dailygoals");
        }
    }
} 