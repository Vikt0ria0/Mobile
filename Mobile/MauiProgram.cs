using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Mobile.ViewModels;
using Mobile.Views;
using CommunityToolkit.Maui;

namespace Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<DailyGoalsViewModel>();
		builder.Services.AddSingleton<MainGoalsViewModel>();
		builder.Services.AddTransient<EditDailyGoalViewModel>();
		builder.Services.AddTransient<EditMainGoalViewModel>();
		builder.Services.AddTransient<CalendarViewModel>();

		builder.Services.AddTransient<DailyGoalsPage>();
		builder.Services.AddTransient<MainGoalsPage>();
		builder.Services.AddTransient<EditDailyGoalPage>();
		builder.Services.AddTransient<EditMainGoalPage>();
		builder.Services.AddTransient<CalendarPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
