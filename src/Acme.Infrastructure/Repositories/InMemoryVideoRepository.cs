using Acme.Core.Models;
using Acme.Core.Repositories;

namespace Acme.Infrastructure.Repositories
{
    internal class InMemoryVideoRepository : IVideoRepository
    {
        public Task<IEnumerable<Video>> GetVideosAsync()
        {
            var videos = new List<Video>
            {
                new Video
                {
                    Id = "1",
                    Title = "Video #1",
                    BulletText = "Bullet Text 1",
                    Description = "Description 1",
                    Duration = 1000
                },
                new Video
                {
                    Id = "2",
                    Title = "Video #2",
                    BulletText = "Bullet Text 2",
                    Description = "Description 2",
                    Duration = 1200
                },
                new Video
                {
                    Id = "3",
                    Title = "Video #3",
                    BulletText = "Bullet Text 3",
                    Description = "Description 3",
                    Duration = 1300
                },
                new Video
                {
                    Id = "4",
                    Title = "Video #4",
                    BulletText = "Bullet Text 4",
                    Description = "Description 4",
                    Duration = 1400
                },
                new Video
                {
                    Id = "5",
                    Title = "Video #5",
                    BulletText = "Bullet Text 5",
                    Description = "Description 5",
                    Duration = 1500
                },
            };

            return Task.FromResult(videos.AsEnumerable());
        }
    }
}
