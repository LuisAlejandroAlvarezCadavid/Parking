using Parking.Domain.Ports;
using Parking.Infrastructure.DataContext;

namespace Parking.Infrastructure.Adapters.Vehicule
{

    [Repository]
    public class VehiculeInsertRepository : GenericRepository<Domain.Entities.Vehicule, Guid>, IVehiculeInsertRepository
    {

        public VehiculeInsertRepository(IntegracionDbContext integracionDbContext) : base(integracionDbContext)
        {
        }

        public async Task<Domain.Entities.Vehicule> InsertVehiculeAsync(Domain.Entities.Vehicule vehicule, CancellationToken cancellationToken)
        {
            return await AddAsync(vehicule, cancellationToken);
        }
    }
}
