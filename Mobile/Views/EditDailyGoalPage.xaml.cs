using Microsoft.Maui.Controls;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class EditDailyGoalPage : ContentPage
    {
        public EditDailyGoalPage(EditDailyGoalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
} 