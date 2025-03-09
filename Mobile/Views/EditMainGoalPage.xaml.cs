using Microsoft.Maui.Controls;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class EditMainGoalPage : ContentPage
    {
        public EditMainGoalPage(EditMainGoalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
} 