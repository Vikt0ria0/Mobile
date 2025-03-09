using Mobile.Models;

namespace Mobile.ViewModels
{
    [QueryProperty("Goal", "goal")]
    public class EditMainGoalViewModel : BaseEditGoalViewModel
    {
        private MainGoal _mainGoal;

        public new MainGoal Goal
        {
            get => _mainGoal;
            set
            {
                if (value is MainGoal mainGoal)
                {
                    _mainGoal = mainGoal;
                    _goal = mainGoal;
                    OnPropertyChanged(nameof(Goal));
                    OnPropertyChanged(nameof(Title));
                    OnPropertyChanged(nameof(Description));
                    OnPropertyChanged(nameof(Category));
                    OnPropertyChanged(nameof(Deadline));
                    OnPropertyChanged(nameof(Progress));
                    OnPropertyChanged(nameof(IsCompleted));
                    OnPropertyChanged(nameof(Urgency));
                }
            }
        }

        public int Urgency
        {
            get => _mainGoal?.Urgency ?? 0;
            set
            {
                if (_mainGoal != null)
                {
                    _mainGoal.Urgency = value;
                    OnPropertyChanged(nameof(Urgency));
                }
            }
        }
    }
} 