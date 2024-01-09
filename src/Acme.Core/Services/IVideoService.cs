using Acme.Core.Models;

namespace Acme.Core.Services
{
    public interface IVideoService
    {
        Task<IEnumerable<Video>> GetVideosAsync();
    }
}
