using Acme.Core.Models;
using Acme.Infrastructure.Dtos;
using AutoMapper;

namespace Acme.Infrastructure
{
    internal class InfrastructureMappingProfile : Profile
    {
        public InfrastructureMappingProfile()
        {
            CreateMap<VideoDto, Video>()
                .ForMember(model => model.Duration, 
                           mapper => mapper.MapFrom(dto => dto.RunningTime));
        }
    }
}
