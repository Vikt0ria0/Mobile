using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Mobile.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mobile.ViewModels
{
    public class MainGoalsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MainGoal> _goals;
        public ObservableCollection<MainGoal> Goals
        {
            get => _goals;
            set
            {
                _goals = value;
                OnPropertyChanged(nameof(Goals));
            }
        }

        public ICommand AddGoalCommand { get; }
        public ICommand DeleteGoalCommand { get; }
        public ICommand EditGoalCommand { get; }
        public ICommand NavigateToCalendarCommand { get; }
        public ICommand NavigateToDailyGoalsCommand { get; }

        public MainGoalsViewModel()
        {
            Goals = new ObservableCollection<MainGoal>();
            LoadGoals();

            AddGoalCommand = new Command(AddGoal);
            DeleteGoalCommand = new Command<MainGoal>(DeleteGoal);
            EditGoalCommand = new Command<MainGoal>(async (goal) => await EditGoal(goal));
            NavigateToCalendarCommand = new Command(async () => await Shell.Current.GoToAsync("//calendar"));
            NavigateToDailyGoalsCommand = new Command(async () => await Shell.Current.GoToAsync("//dailygoals"));
        }

        private void LoadGoals()
        {
            // Тестовые данные
            Goals.Add(new MainGoal
            {
                Title = "Завершить проект",
                Deadline = new DateTime(2023, 12, 31),
                Category = "Работа",
                Progress = 75,
                Urgency = 90,
                Color = "#E8E6FF",
                Image = "project.png"
            });

            Goals.Add(new MainGoal
            {
                Title = "Купить подарки",
                Deadline = new DateTime(2023, 12, 20),
                Category = "Личное",
                Progress = 30,
                Urgency = 60,
                Color = "#E8E6FF",
                Image = "shopping.png"
            });
        }

        private void DeleteGoal(MainGoal goal)
        {
            if (goal != null)
            {
                Goals.Remove(goal);
            }
        }

        private async void AddGoal()
        {
            string title = await App.Current.MainPage.DisplayPromptAsync("Новая цель", "Введите название цели:");
            if (string.IsNullOrEmpty(title)) return;

            string category = await App.Current.MainPage.DisplayPromptAsync("Категория", "Введите категорию:");
            if (string.IsNullOrEmpty(category)) return;

            var goal = new MainGoal
            {
                Title = title,
                Category = category,
                Deadline = DateTime.Now.AddDays(7),
                Progress = 0,
                Urgency = 50,
                Color = "#E8E6FF",
                Image = "new_goal.png"
            };

            Goals.Add(goal);
        }

        private async Task EditGoal(MainGoal goal)
        {
            var parameters = new Dictionary<string, object>
            {
                { "goal", goal }
            };
            await Shell.Current.GoToAsync($"editmaingoal", parameters);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 