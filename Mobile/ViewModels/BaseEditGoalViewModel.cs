using System.ComponentModel;
using System.Windows.Input;
using Mobile.Models;

namespace Mobile.ViewModels
{
    public abstract class BaseEditGoalViewModel : INotifyPropertyChanged
    {
        protected Goal? _goal;

        public string? Title
        {
            get => _goal?.Title;
            set
            {
                if (_goal != null)
                {
                    _goal.Title = value ?? string.Empty;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }

        public string? Description 
        {
            get => _goal?.Description;
            set
            {
                if (_goal != null)
                {
                    _goal.Description = value ?? string.Empty;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string? Category
        {
            get => _goal?.Category;
            set
            {
                if (_goal != null)
                {
                    _goal.Category = value ?? string.Empty;
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

        public ICommand? SaveCommand { get; protected set; }
        public ICommand? CancelCommand { get; protected set; }

        protected BaseEditGoalViewModel()
        {
            SaveCommand = new Command(async () => await Save());
            CancelCommand = new Command(async () => await Cancel());
        }

        protected virtual async Task Save()
        {
            await Shell.Current.GoToAsync("..");
        }

        protected virtual async Task Cancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 