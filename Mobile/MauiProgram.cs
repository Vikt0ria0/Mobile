using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Mobile.ViewModels;
using Mobile.Views;
using Mobile.Repository;
using Mobile.UseCases;
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

		// Регистрация репозиториев
		builder.Services.AddSingleton<IGoalRepository, FakeGoalRepository>();

		// Регистрация UseCases
		builder.Services.AddTransient<EditGoalUseCase>();

		// Регистрация ViewModels
		builder.Services.AddTransient<EditGoalViewModel>();
		builder.Services.AddSingleton<DailyGoalsViewModel>();
		builder.Services.AddSingleton<MainGoalsViewModel>();
		builder.Services.AddTransient<EditDailyGoalViewModel>();
		builder.Services.AddTransient<EditMainGoalViewModel>();
		builder.Services.AddTransient<CalendarViewModel>();

		// Регистрация Views
		builder.Services.AddTransient<EditGoalPage>();
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
