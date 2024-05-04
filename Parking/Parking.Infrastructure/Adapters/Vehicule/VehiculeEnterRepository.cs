using Parking.Domain.Ports;
using Parking.Infrastructure.DataContext;

namespace Parking.Infrastructure.Adapters.Vehicule
{

    [Repository]
    public class VehiculeEnterRepository : GenericRepository<Domain.Entities.Vehicule, Guid>, IVehiculeEnterRepository
    {

        public VehiculeEnterRepository(IntegracionDbContext integracionDbContext) : base(integracionDbContext)
        {
        }

        public async Task<Domain.Entities.Vehicule> EnterVehiculeAsync(Domain.Entities.Vehicule vehicule, CancellationToken cancellationToken)
        {
            return await AddAsync(vehicule, cancellationToken);
        }
    }
}
