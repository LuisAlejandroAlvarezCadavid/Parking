using Parking.Domain.Exceptions;
using Parking.Domain.Ports;
using Parking.Infrastructure.DataContext;

namespace Parking.Infrastructure.Adapters.Vehicule
{

    [Repository]
    public class VehiculeInsertRepository : GenericRepository<Domain.Entities.Vehicule, Guid>, IVehiculeRepository
    {

        public VehiculeInsertRepository(IntegracionDbContext integracionDbContext) : base(integracionDbContext)
        {

        }

        public async Task<Domain.Entities.Vehicule> InsertVehiculeAsync(Domain.Entities.Vehicule vehicule, CancellationToken cancellationToken)
        {
            return await AddAsync(vehicule, cancellationToken);
        }

        public async Task<Domain.Entities.Vehicule> GetVehiculeAsync(string plate, CancellationToken cancellationToken)
        {
            var vehicule = (await GetAsync(cancellationToken)).Find(vehicule => vehicule.Plate == plate && vehicule.LeaveTime == null);
            return vehicule ?? throw new VehiculeMotorCycleException("La placa ingresada no coincide con ningun vehiculo o moto ingresada");
        }
    }
}
