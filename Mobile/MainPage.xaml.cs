using Mobile.Models;
using Mobile.Services;

namespace Mobile;

public partial class MainPage : ContentPage
{
    private readonly GoalService _goalService;

    //public MainPage()
    //{
    //    InitializeComponent();
    //    _goalService = new GoalService();
    //    BindingContext = _goalService;
    //}

    private async void OnAddGoalClicked(object sender, EventArgs e)
    {
        var title = await DisplayPromptAsync("Новая цель", "Введите название цели:");
        if (string.IsNullOrEmpty(title)) return;

        var description = await DisplayPromptAsync("Описание", "Введите описание цели:");
        if (string.IsNullOrEmpty(description)) return;

        var goal = new Goal
        {
            Title = title,
            Description = description,
            Deadline = DateTime.Now.AddDays(7),
            Progress = 0,
            Category = "Общее"
        };

        _goalService.AddGoal(goal);
    }
}
