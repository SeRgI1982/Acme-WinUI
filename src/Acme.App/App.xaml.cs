using Acme.App.Pages;
using Acme.Core;
using Acme.Core.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Acme.Infrastructure;
using Acme.Core.Services;
using Acme.App.Utils;
using Microsoft.Extensions.Logging.Debug;

namespace Acme.App
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddAcmeInfrastructure()
                             .AddAcmeCore()
                             .AddSingleton<IDialogService, Dialog>()
                             .AddSingleton<ILoggerProvider, DebugLoggerProvider>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            Ioc.Default.ConfigureServices(serviceProvider);

            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame frame = new Frame();
            var shellViewModel = Ioc.Default.GetService<IShellViewModel>();
            frame.Navigate(typeof(ShellPage), null);

            var shellPage = frame.Content as ShellPage;
            if (shellPage != null)
            {
                shellPage.DataContext = shellViewModel;
            }

            _window = new Window();
            _window.Content = frame;
            _window.Activate();

            var dialogService = Ioc.Default.GetService<IDialogService>();

            if (dialogService is Dialog winUiDialog)
            {
                winUiDialog.SetOwnerWindow(_window);
            }
        }

        private Window _window;
    }
}
