using Acme.App.Wpf.Pages;
using Acme.App.Wpf.Utils;
using Acme.Core;
using Acme.Core.Services;
using Acme.Core.ViewModels;
using Acme.Infrastructure;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System.Windows;
using System.Windows.Controls;

namespace Acme.App.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAcmeInfrastructure()
                             .AddAcmeCore()
                             .AddSingleton<IDialogService, Dialog>()
                             .AddSingleton<ILoggerProvider, DebugLoggerProvider>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Ioc.Default.ConfigureServices(serviceProvider);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            
        }

        private Window _window;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Frame frame = new Frame();
            var shellViewModel = Ioc.Default.GetService<IShellViewModel>();
            frame.Navigate(typeof(ShellPage), null);

            var shellPage = frame.Content as ShellPage;
            if (shellPage != null)
            {
                shellPage.DataContext = shellViewModel;
            }

            _window = new Window
            {
                Content = new ShellPage { DataContext = shellViewModel }
            };

            MainWindow = _window;
            MainWindow.Show();
        }
    }
}
