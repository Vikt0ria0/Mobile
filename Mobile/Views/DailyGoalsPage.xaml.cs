using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Mobile.ViewModels;
using Mobile.Handlers;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyGoalsPage : ContentPage
    {
        public DailyGoalsPage(DailyGoalsViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            
            // Инициализация обработчика свайпов
            _ = new SwipeGestureHandler(MainGrid, "//MainGoals");
        }
    }
}