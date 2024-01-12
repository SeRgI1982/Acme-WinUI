using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using Acme.Infrastructure;
using Acme.Core;
using Acme.Core.Services;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace Acme.App.Maui
{
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
                })
                .Services.AddAcmeInfrastructure()
                         .AddAcmeCore()
                         .AddSingleton<IDialogService, Utils.Dialog>()
                         .AddSingleton<ILoggerProvider, DebugLoggerProvider>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            var serviceProvider = builder.Services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(serviceProvider);

            return builder.Build();
        }
    }
}
