using Microsoft.Extensions.DependencyInjection;
using Parking.Domain.Services;
using Parking.Infrastructure.Adapters;

namespace Parking.Infrastructure.Extensions
{
    public static class LoadServices
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // all services with domain service attribute, we can also do this "by convention",
            // naming services with suffix "Service" if decide to remove the domain service decorator
            var _services = AppDomain.CurrentDomain.GetAssemblies()
                  .Where(assembly =>
                  {
                      return (assembly.FullName is null) || assembly.FullName.Contains("Domain", StringComparison.InvariantCulture);
                  })
                  .SelectMany(s => s.GetTypes())
                  .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));

            // Ditto, but repositories
            var _repositories = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly =>
                {
                    return (assembly.FullName is null) || assembly.FullName.Contains("Infrastructure", StringComparison.InvariantCulture);
                })
                .SelectMany(s => s.GetTypes())
                .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(RepositoryAttribute)));

            // svc
            foreach (var service in _services)
            {
                Type? iface = service.GetInterfaces().Length > 0 ? service.GetInterfaces().Single() : null;
                if (iface != null)
                {
                    services.AddTransient(iface, service);
                }
                else
                {
                    services.AddTransient(service);
                }
            }

            // repos
            foreach (var repo in _repositories)
            {
                var iface = repo.GetInterfaces();
                services.AddTransient(iface[1], repo);
            }

            return services;
        }
    }
}
