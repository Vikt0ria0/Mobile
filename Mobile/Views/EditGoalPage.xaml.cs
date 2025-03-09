using Microsoft.Maui.Controls;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class EditGoalPage : ContentPage
    {
        public EditGoalPage(EditGoalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
} 