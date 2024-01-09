using Acme.Core.Services;
using Acme.Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Acme.Core.Tests")]
namespace Acme.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddAcmeCore(this IServiceCollection services)
        {
            services.AddTransient<IShellViewModel, ShellViewModel>();
            services.AddSingleton<IVideoService, VideoService>();
            return services;
        }
    }
}
