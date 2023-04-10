using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using MAUI.LMSystem.ViewModels;
using MAUI.LMSystem.Views;

namespace MAUI.LMSystem;

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

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

        builder.Services.AddTransient<ViewCoursesPage>();
        builder.Services.AddTransient<ViewCoursesViewModel>();

        return builder.Build();
    }
}

