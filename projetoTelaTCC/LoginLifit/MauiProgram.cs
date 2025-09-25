using LoginLifit.ViewModels;
using LoginLifit.Views;

namespace LoginLifit;

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

        // Registrando Views
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<HomePage>();


        // Registrando ViewModels
        builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();

        return builder.Build();
    }
}