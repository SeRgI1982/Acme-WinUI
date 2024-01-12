using Acme.Core.Services;

namespace Acme.App.Maui.Utils
{
    internal class Dialog : IDialogService
    {
        public Task ShowMessageAsync(string title, string content)
        {
            Application.Current?.MainPage?.DisplayAlert(title, content, "OK");
            return Task.CompletedTask;
        }
    }
}
