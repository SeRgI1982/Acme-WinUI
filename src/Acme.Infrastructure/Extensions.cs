using Acme.Core.Repositories;
using Acme.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddAcmeInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile<InfrastructureMappingProfile>())))
                    //.AddSingleton<IVideoRepository, InMemoryVideoRepository>()
                    .AddSingleton<IVideoRepository, FileVideoRepository>();
                    //.AddHttpClient<IVideoRepository, WebApiVideoRepository>(client => client.BaseAddress = new Uri(@"https://assets.acmeaom.com/"));
            return services;
        }
    }
}
