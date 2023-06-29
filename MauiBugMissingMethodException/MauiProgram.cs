using MauiBugMissingMethodException.View;
using MauiBugMissingMethodException.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiBugMissingMethodException;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		//ViewModel registration
		builder.Services.AddTransient<BugPageViewModel>();

		//Page registration
		builder.Services.AddTransient<BugPage>();

		return builder.Build();
	}
}
