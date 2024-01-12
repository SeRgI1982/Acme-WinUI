using Acme.Core.ViewModels;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace Acme.App.Maui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            var viewModel = Ioc.Default.GetRequiredService<IShellViewModel>();
            BindingContext = viewModel;

            viewModel.InitializeCommand.Execute(null);
        }
    }
}
