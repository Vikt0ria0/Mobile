using System.ComponentModel;
using System.Windows.Input;
using Mobile.Models;

namespace Mobile.ViewModels
{
    [QueryProperty("Goal", "goal")]
    public class EditGoalViewModel : INotifyPropertyChanged
    {
        private Goal _goal;
        private bool _isMainGoal;
        private MainGoal _mainGoal;
        
        public Goal Goal
        {
            get => _goal;
            set
            {
                _goal = value;
                _mainGoal = value as MainGoal;
                IsMainGoal = _mainGoal != null;
                OnPropertyChanged(nameof(Goal));
            }
        }
        
        public bool IsMainGoal
        {
            get => _isMainGoal;
            set
            {
                _isMainGoal = value;
                OnPropertyChanged(nameof(IsMainGoal));
            }
        }

        public string Title
        {
            get => _goal?.Title;
            set
            {
                if (_goal != null)
                {
                    _goal.Title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string Description
        {
            get => _goal?.Description;
            set
            {
                if (_goal != null)
                {
                    _goal.Description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Category
        {
            get => _goal?.Category;
            set
            {
                if (_goal != null)
                {
                    _goal.Category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public DateTime Deadline
        {
            get => _goal?.Deadline ?? DateTime.Now;
            set
            {
                if (_goal != null)
                {
                    _goal.Deadline = value;
                    OnPropertyChanged(nameof(Deadline));
                }
            }
        }

        public int Progress
        {
            get => _goal?.Progress ?? 0;
            set
            {
                if (_goal != null)
                {
                    _goal.Progress = value;
                    OnPropertyChanged(nameof(Progress));
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

        public bool IsCompleted
        {
            get => _goal?.IsCompleted ?? false;
            set
            {
                if (_goal != null)
                {
                    _goal.IsCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditGoalViewModel()
        {
            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
        }

        private async Task Save()
        {
            // Возвращаемся на предыдущую страницу
            await Shell.Current.GoToAsync("..");
        }

        private async Task Cancel()
        {
            // Возвращаемся на предыдущую страницу без сохранения
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 