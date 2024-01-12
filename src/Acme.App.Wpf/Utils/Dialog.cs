using Acme.Core.Services;
using System.Windows;

namespace Acme.App.Wpf.Utils
{
    internal class Dialog : IDialogService
    {
        public Task ShowMessageAsync(string title, string content)
        {
            MessageBox.Show(title, content);
            return Task.CompletedTask;
        }
    }
}
