using Mobile.Models;

namespace Mobile.ViewModels
{
    [QueryProperty("Goal", "goal")]
    public class EditDailyGoalViewModel : BaseEditGoalViewModel
    {
        public new Goal Goal
        {
            get => _goal;
            set
            {
                if (value is Goal goal)
                {
                    _goal = goal;
                    OnPropertyChanged(nameof(Goal));
                    OnPropertyChanged(nameof(Title));
                    OnPropertyChanged(nameof(Description));
                    OnPropertyChanged(nameof(Category));
                    OnPropertyChanged(nameof(Deadline));
                    OnPropertyChanged(nameof(Progress));
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }
    }
} 