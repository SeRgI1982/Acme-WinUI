using Acme.Core.Models;
using Acme.Core.Repositories;
using Acme.Infrastructure.Dtos;
using AutoMapper;
using CommunityToolkit.Diagnostics;
using Newtonsoft.Json;
using System.Reflection;

namespace Acme.Infrastructure.Repositories
{
    internal class FileVideoRepository : IVideoRepository
    {
        private readonly IMapper _mapper;

        public FileVideoRepository(IMapper mapper)
        {
            Guard.IsNotNull(nameof(mapper));

            _mapper = mapper;
        }

        public async Task<IEnumerable<Video>> GetVideosAsync()
        {
            Assembly assembly = this.GetType().Assembly;
            var resourceName = assembly.GetName().Name + "." + "Resources" + ".uwpvideos.json";
            using var stream = assembly.GetManifestResourceStream(resourceName);
            
            if (stream is null)
            {
                return Array.Empty<Video>();
            }

            using var streamReader = new StreamReader(stream);
            var json = await streamReader.ReadToEndAsync();
            var dtos = JsonConvert.DeserializeObject<VideoDto[]>(json);
            var models = _mapper.Map<IEnumerable<Video>>(dtos);
            return models;
        }
    }
}
