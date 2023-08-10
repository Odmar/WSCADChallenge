using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using WSCADCodeChallenge.Broker.FileSystemBroker;
using WSCADCodeChallenge.Services;
using WSCADCodeChallenge.ViewModels;
using WSCADCodeChallenge.Views;

namespace WSCADCodeChallenge;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.RegisterServices()
			.RegisterViewModels();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<IFileSystemBroker, JsonFileSystemBroker>();
		mauiAppBuilder.Services.AddSingleton<ShapeService>();

		return mauiAppBuilder;
	}

	public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<MainPage>();
		mauiAppBuilder.Services.AddSingleton<MainViewModel>();
		return mauiAppBuilder;
	}
}
