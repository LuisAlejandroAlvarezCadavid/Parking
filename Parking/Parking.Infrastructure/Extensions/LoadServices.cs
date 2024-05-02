using Microsoft.Extensions.DependencyInjection;

namespace Parking.Infrastructure.Extensions
{
    public static class LoadServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
