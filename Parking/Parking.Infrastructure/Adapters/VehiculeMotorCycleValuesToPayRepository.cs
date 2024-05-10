using Parking.Domain.Entities;
using Parking.Domain.Exceptions;
using Parking.Domain.Ports;
using Parking.Infrastructure.DataContext;

namespace Parking.Infrastructure.Adapters
{
    [Repository]
    public class VehiculeMotorCycleValuesToPayRepository : GenericRepository<VehiculeMotorCycleValuesToPay, Guid>, IVehiculeMotorCycleValuesToPayRepository
    {
        public VehiculeMotorCycleValuesToPayRepository(IntegracionDbContext integracionDbContext) : base(integracionDbContext) { }

        public async Task<VehiculeMotorCycleValuesToPay> GetVehiculeMotorCycleValuesTOPay(string vehiculeType, CancellationToken cancellationToken)
        {
            return (await GetAsync(cancellationToken)).Find(valueToPay => valueToPay.VehiculeType == vehiculeType) ?? throw new VehiculeMotorCycleException("El tipo de vehiculo no coincide con ningun tipo");
        }
    }
}
