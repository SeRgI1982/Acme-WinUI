using Acme.Core.Models;
using Acme.Core.Services;
using Acme.Core.ViewModels;
using Microsoft.Extensions.Logging.Debug;
using Moq;
using Xunit;

namespace Acme.Core.Tests.ViewModels
{
    public class ShellViewModelTests
    {
        [Fact]
        public async void ShouldContainsVideosAfterInitialization()
        {
            // Arrange
            var videos = new List<Video> { new Video { Title = "Test Video" } };
            var dialogServiceMock = new Mock<IDialogService>();
            var videoServiceMock = new Mock<IVideoService>();
            videoServiceMock.Setup(x => x.GetVideosAsync()).ReturnsAsync(videos);
            var loggerProvider = new DebugLoggerProvider();
            var shellViewModel = new ShellViewModel(videoServiceMock.Object, loggerProvider, dialogServiceMock.Object);

            // Act
            await shellViewModel.InitializeCommand.ExecuteAsync(null);

            // Assert
            Assert.NotNull(shellViewModel.Videos);
            Assert.Collection(shellViewModel.Videos, video => Assert.Equal("Test Video", video.Title));
        }
    }
}
