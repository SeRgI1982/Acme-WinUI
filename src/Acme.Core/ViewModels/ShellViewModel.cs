using Acme.Core.Models;
using Acme.Core.Services;
using CommunityToolkit.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace Acme.Core.ViewModels
{
    internal partial class ShellViewModel : ObservableObject, IShellViewModel
    {
        private readonly ILogger _logger;
        private readonly IDialogService _dialogService;
        private readonly IVideoService _service;

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private Video _selectedVideo;

        [ObservableProperty]
        private int _selectedVideoIndex;

        [ObservableProperty]
        private IEnumerable<Video> _videos;

        public ShellViewModel(IVideoService service, ILoggerProvider loggerProvider, IDialogService dialogService)
        {
            Guard.IsNotNull(nameof(loggerProvider));
            Guard.IsNotNull(nameof(service));
            Guard.IsNotNull(nameof(dialogService));

            _service = service;
            _logger = loggerProvider.CreateLogger(nameof(ShellViewModel));
            _dialogService = dialogService;
        }

        [RelayCommand]
        private async Task InitializeAsync()
        {
            try
            {
                IsBusy = true;

                var videos = await _service.GetVideosAsync();

                // Simulate long loading
                await Task.Delay(2000);

                Videos = videos;
                SelectedVideo = Videos.FirstOrDefault();
                MovePrevCommand.NotifyCanExecuteChanged();
                MoveNextCommand.NotifyCanExecuteChanged();
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to load videos.", ex);
                await _dialogService.ShowMessageAsync("Error", "Unable to load videos.");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanMoveNext(int index) => Videos is not null && index + 1 < Videos.Count();

        private bool CanMovePrev(int index) => Videos is not null && index - 1 >= 0;

        [RelayCommand(CanExecute = nameof(CanMoveNext))]
        private void MoveNext(int index) => SelectedVideo = Videos.ElementAtOrDefault(index + 1);

        [RelayCommand(CanExecute = nameof(CanMovePrev))]
        private void MovePrev(int index) => SelectedVideo = Videos.ElementAtOrDefault(index - 1);

        partial void OnSelectedVideoChanged(Video value)
        {
            SelectedVideoIndex = Videos.Select((v, i) => new { Video = v, Index = i })
                                       .FirstOrDefault(v => v.Video == value)?.Index ?? -1;
        }
    }
}
