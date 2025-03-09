using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Mobile.Models;
using Microsoft.Maui.Controls;

namespace Mobile.ViewModels
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        private DateTime _currentDate;
        private ObservableCollection<Goal> _todayGoals;
        private readonly DailyGoalsViewModel _dailyGoalsViewModel;
        private readonly MainGoalsViewModel _mainGoalsViewModel;

        public DateTime CurrentDate
        {
            get => _currentDate;
            set
            {
                if (_currentDate != value)
                {
                    _currentDate = value;
                    OnPropertyChanged(nameof(CurrentDate));
                    OnPropertyChanged(nameof(CurrentMonthYear));
                    LoadGoals();
                }
            }
        }

        public string CurrentMonthYear => $"{CurrentDate.ToString("MMMM")} {CurrentDate.Year}";

        public ObservableCollection<Goal> TodayGoals
        {
            get => _todayGoals;
            set
            {
                _todayGoals = value;
                OnPropertyChanged(nameof(TodayGoals));
            }
        }

        public ICommand NavigateToMainGoalsCommand { get; }
        public ICommand NavigateToDailyGoalsCommand { get; }
        public ICommand PreviousMonthCommand { get; }
        public ICommand NextMonthCommand { get; }
        public ICommand GoToTodayCommand { get; }

        public CalendarViewModel(DailyGoalsViewModel dailyGoalsViewModel, MainGoalsViewModel mainGoalsViewModel)
        {
            _dailyGoalsViewModel = dailyGoalsViewModel;
            _mainGoalsViewModel = mainGoalsViewModel;
            
            CurrentDate = DateTime.Today;
            TodayGoals = new ObservableCollection<Goal>();
            
            NavigateToMainGoalsCommand = new Command(async () => await Shell.Current.GoToAsync("//maingoals"));
            NavigateToDailyGoalsCommand = new Command(async () => await Shell.Current.GoToAsync("//dailygoals"));
            PreviousMonthCommand = new Command(PreviousMonth);
            NextMonthCommand = new Command(NextMonth);
            GoToTodayCommand = new Command(GoToToday);

            LoadGoals();

            // Подписываемся на изменения в коллекциях целей
            _dailyGoalsViewModel.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(DailyGoalsViewModel.Goals))
                    LoadGoals();
            };

            _mainGoalsViewModel.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == nameof(MainGoalsViewModel.Goals))
                    LoadGoals();
            };
        }

        private void PreviousMonth()
        {
            CurrentDate = CurrentDate.AddMonths(-1);
        }

        private void NextMonth()
        {
            CurrentDate = CurrentDate.AddMonths(1);
        }

        private void GoToToday()
        {
            CurrentDate = DateTime.Today;
        }

        private void LoadGoals()
        {
            var allGoals = new List<Goal>();
            
            // Добавляем ежедневные цели
            var dailyGoals = _dailyGoalsViewModel.Goals
                .Where(g => g.Date.Date == CurrentDate.Date)
                .Select(g => new Goal
                {
                    Title = g.Title,
                    Description = g.Description,
                    Deadline = g.Deadline,
                    IsCompleted = g.IsCompleted,
                    Category = g.Category,
                    Progress = g.Progress,
                    Urgency = g.Urgency,
                    Color = g.Color,
                    Image = g.Image
                });
            allGoals.AddRange(dailyGoals);

            // Добавляем основные цели
            var mainGoals = _mainGoalsViewModel.Goals
                .Where(g => g.Deadline.Date == CurrentDate.Date)
                .Select(g => new Goal
                {
                    Title = g.Title,
                    Description = g.Description,
                    Deadline = g.Deadline,
                    IsCompleted = g.IsCompleted,
                    Category = g.Category,
                    Progress = g.Progress,
                    Urgency = g.Urgency,
                    Color = g.Color,
                    Image = g.Image
                });
            allGoals.AddRange(mainGoals);

            // Сортируем все цели по времени
            var sortedGoals = allGoals.OrderBy(g => g.Deadline.TimeOfDay);
            TodayGoals = new ObservableCollection<Goal>(sortedGoals);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 