using Microsoft.Maui.Controls;
using Mobile.ViewModels;

namespace Mobile.Views
{
    public partial class CalendarPage : ContentPage
    {
        public CalendarPage(CalendarViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void OnDateSelected(object sender, DateChangedEventArgs e)
        {
            if (BindingContext is CalendarViewModel viewModel)
            {
                viewModel.CurrentDate = e.NewDate;
            }
        }
    }
} 