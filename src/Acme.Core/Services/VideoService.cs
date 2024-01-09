using Acme.Core.Models;
using Acme.Core.Repositories;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Acme.Core.Services
{
    internal class VideoService : IVideoService
    {
        // Service doesn't need to know what kind of provider deliver data
        private readonly IVideoRepository _repository;
        private readonly ILogger _logger;

        public VideoService(IVideoRepository repository, ILoggerProvider loggerProvider)
        {
            Guard.IsNotNull(nameof(loggerProvider));
            Guard.IsNotNull(nameof(repository));
            
            _logger = loggerProvider.CreateLogger(nameof(VideoService));
            _repository = repository;
        }

        public async Task<IEnumerable<Video>> GetVideosAsync()
        {
            try
            {
                // Of course, it is simple example but we can provide more features into service (caching, notifications etc.)
                // If we wish to have application service, it can contains even business logic like in domain services - whole business process
                // Of course, in thin client, the logic is on the backend side and such service only delegates commands/requests.
                var videos = await _repository.GetVideosAsync();
                return videos;
            }
            catch (Exception ex)
            {
                _logger.LogError("Unable to gather videos.", ex);
                throw;
            }
        }
    }
}
