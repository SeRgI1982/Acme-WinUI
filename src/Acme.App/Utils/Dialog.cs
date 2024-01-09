using Acme.Core.Services;
using CommunityToolkit.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Threading.Tasks;

namespace Acme.App.Utils
{
    internal class Dialog : IDialogService
    {
        private Window _ownerWindow;

        public async Task ShowMessageAsync(string title, string content)
        {
            ContentDialog contentDialog = new ContentDialog()
            {
                XamlRoot = _ownerWindow.Content.XamlRoot,
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            await contentDialog.ShowAsync();
        }

        public void SetOwnerWindow(Window window)
        {
            Guard.IsNotNull(window, nameof(window));

            _ownerWindow = window;
        }
    }
}
