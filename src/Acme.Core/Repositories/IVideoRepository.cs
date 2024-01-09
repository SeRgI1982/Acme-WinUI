using Acme.Core.Models;

namespace Acme.Core.Repositories
{
    public interface IVideoRepository
    {
        public Task<IEnumerable<Video>> GetVideosAsync();
    }
}
