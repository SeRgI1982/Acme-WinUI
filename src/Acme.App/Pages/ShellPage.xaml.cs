using Acme.Core.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Acme.App.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShellPage : Page
    {
        public ShellPage()
        {
            this.InitializeComponent();

            // Of course we can have a view model locator here, but I'm just trying to keep it simple
            DataContext = Ioc.Default.GetRequiredService<IShellViewModel>();
        }

        public Visibility NullToVisibility(object value) => value == null ? Visibility.Collapsed : Visibility.Visible;
    }
}
