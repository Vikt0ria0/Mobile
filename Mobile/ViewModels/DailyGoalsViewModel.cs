using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using Microsoft.Maui.Controls;
using Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public class DailyGoalsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Goal> _goals;
        public ObservableCollection<Goal> Goals
        {
            get => _goals;
            set
            {
                _goals = value;
                OnPropertyChanged(nameof(Goals));
                OnPropertyChanged(nameof(HasNoGoals));
            }
        }

        public bool HasNoGoals => !Goals?.Any() ?? true;

        public ICommand AddGoalCommand { get; }
        public ICommand DeleteGoalCommand { get; }
        public ICommand EditGoalCommand { get; }
        public ICommand ToggleCompletedCommand { get; }
        public ICommand NavigateToCalendarCommand { get; }
        public ICommand NavigateToMainGoalsCommand { get; }

        public DailyGoalsViewModel()
        {
            Goals = new ObservableCollection<Goal>();
            LoadGoals();

            AddGoalCommand = new Command(AddGoal);
            DeleteGoalCommand = new Command<Goal>(DeleteGoal);
            EditGoalCommand = new Command<Goal>(async (goal) => await EditGoal(goal));
            ToggleCompletedCommand = new Command<Goal>(ToggleCompleted);
            NavigateToCalendarCommand = new Command(async () => await Shell.Current.GoToAsync("//calendar"));
            NavigateToMainGoalsCommand = new Command(async () => await Shell.Current.GoToAsync("//maingoals"));
        }

        private void LoadGoals()
        {
            // Добавляем тестовые цели
            Goals.Add(new Goal 
            { 
                Title = "Прочитать 20 страниц",
                Description = "Чтение книги по саморазвитию",
                Date = DateTime.Today,
                Deadline = DateTime.Today.AddDays(1),
                Progress = 0,
                Category = "Общее"
            });

            Goals.Add(new Goal 
            { 
                Title = "Сделать уборку",
                Description = "Генеральная уборка в квартире",
                Date = DateTime.Today,
                Deadline = DateTime.Today.AddDays(1),
                Progress = 0,
                Category = "Общее"
            });

            Goals.Add(new Goal
            {
                Title = "Сделать презентацию",
                Description = "Подготовить слайды для встречи",
                Category = "Работа",
                Deadline = DateTime.Now.AddDays(1),
                Progress = 30
            });
        }

        private void DeleteGoal(Goal goal)
        {
            if (goal != null)
            {
                Goals.Remove(goal);
                OnPropertyChanged(nameof(HasNoGoals));
            }
        }

        private void ToggleCompleted(Goal goal)
        {
            if (goal != null)
            {
                goal.IsCompleted = !goal.IsCompleted;
                goal.Progress = goal.IsCompleted ? 100 : 0;
            }
        }

        private async void AddGoal()
        {
            string title = await App.Current.MainPage.DisplayPromptAsync("Новая цель", "Введите название цели:");
            if (string.IsNullOrEmpty(title)) return;

            string description = await App.Current.MainPage.DisplayPromptAsync("Описание", "Введите описание цели:");
            if (string.IsNullOrEmpty(description)) return;

            var goal = new Goal
            {
                Title = title,
                Description = description,
                Date = DateTime.Today,
                Deadline = DateTime.Now.AddDays(7),
                Progress = 0,
                Category = "Общее"
            };

            Goals.Add(goal);
            OnPropertyChanged(nameof(HasNoGoals));
        }

        private async Task EditGoal(Goal goal)
        {
            var parameters = new Dictionary<string, object>
            {
                { "goal", goal }
            };
            await Shell.Current.GoToAsync($"editdailygoal", parameters);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 