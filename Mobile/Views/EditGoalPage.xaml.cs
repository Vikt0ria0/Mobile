using Microsoft.Maui.Controls;
using Mobile.ViewModels;

namespace Mobile.Views
{
    [QueryProperty(nameof(GoalId), "id")]
    public partial class EditGoalPage : ContentPage
    {
        private readonly EditGoalViewModel _viewModel;
        private string _goalId;

        public string GoalId
        {
            get => _goalId;
            set
            {
                _goalId = value;
                LoadGoal();
            }
        }

        public EditGoalPage(EditGoalViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            BindingContext = viewModel;
        }

        private async void LoadGoal()
        {
            await _viewModel.InitializeAsync(_goalId);
        }
    }
} 