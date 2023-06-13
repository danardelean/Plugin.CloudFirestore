using Microsoft.Extensions.Logging;
using Plugin.CloudFirestore.Sample.ViewModels;

namespace Plugin.CloudFirestore.Sample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UsePrism(prism => {
				// Register Services and setup initial Navigation
				prism.RegisterTypes(containerRegistry =>
				 {
					 containerRegistry.RegisterForNavigation<NavigationPage>();
					 containerRegistry.RegisterForNavigation<MainPage>();
					 containerRegistry.RegisterForNavigation<NewTodoItemPage>();
					 containerRegistry.RegisterForNavigation<TodoItemDetailPage>();
				 })
				.OnAppStart(navigationService => navigationService.CreateBuilder()
					.AddSegment<MainPageViewModel>()
					.NavigateAsync(HandleNavigationError));
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    private static void HandleNavigationError(Exception ex)
    {
        Console.WriteLine(ex);
        System.Diagnostics.Debugger.Break();
    }
}

