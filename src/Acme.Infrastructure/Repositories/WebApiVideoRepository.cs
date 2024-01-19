using Acme.Core.Models;
using Acme.Core.Repositories;
using Acme.Infrastructure.Dtos;
using AutoMapper;
using CommunityToolkit.Diagnostics;
using System.Net.Http.Json;

namespace Acme.Infrastructure.Repositories
{
    internal class WebApiVideoRepository : IVideoRepository
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public WebApiVideoRepository(HttpClient client, IMapper mapper)
        {
            Guard.IsNotNull(nameof(client));
            Guard.IsNotNull(nameof(mapper));

            _client = client;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Video>> GetVideosAsync()
        {
            string requestUri = "videos.json";
            var result = await _client.GetFromJsonAsync<List<VideoDto>>(requestUri);
            var dtos = result ?? new List<VideoDto>();
            var models = _mapper.Map<IEnumerable<Video>>(dtos);
            return models;
        }
    }
}
