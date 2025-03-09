using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Mobile.Views;

namespace Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            // Регистрация маршрутов
            Routing.RegisterRoute("MainGoals", typeof(MainGoalsPage));
            Routing.RegisterRoute("dailygoals", typeof(DailyGoalsPage));
            Routing.RegisterRoute("editdailygoal", typeof(EditDailyGoalPage));
            Routing.RegisterRoute("editmaingoal", typeof(EditMainGoalPage));
            Routing.RegisterRoute("calendar", typeof(CalendarPage));
        }
    }
}
