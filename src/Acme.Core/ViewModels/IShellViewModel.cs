using Acme.Core.Models;
using CommunityToolkit.Mvvm.Input;

namespace Acme.Core.ViewModels
{
    public interface IShellViewModel
    {
        bool IsBusy { get; }

        Video SelectedVideo { get; set; }

        IEnumerable<Video> Videos { get; }

        IAsyncRelayCommand InitializeCommand { get; }

        IRelayCommand<int> MoveNextCommand { get; }

        IRelayCommand<int> MovePrevCommand { get; }
    }
}
