using Parking.Domain.Exceptions;
using Parking.Domain.Ports;
using Parking.Infrastructure.DataContext;
using Parking.Infrastructure.Resources;

namespace Parking.Infrastructure.Adapters.MotorCycle
{
    [Repository]
    public class MotorCycleInsertRepository : GenericRepository<Domain.Entities.MotorCycle, Guid>, IMotorCycleRepository
    {
        public MotorCycleInsertRepository(IntegracionDbContext integracionDbContext) : base(integracionDbContext)
        {
        }

        public async Task<Domain.Entities.MotorCycle> InsertMotorCycleAsync(Domain.Entities.MotorCycle vehicule, CancellationToken cancellationToken)
        {
            return await AddAsync(vehicule, cancellationToken);
        }

        public async Task<Domain.Entities.MotorCycle> GetMotorCycleAsync(string plate, CancellationToken cancellationToken)
        {
            var motorCycle = (await GetAsync(cancellationToken)).Find(motorCycle => motorCycle.Plate == plate && motorCycle.LeaveTime == null);
            return motorCycle ?? throw new VehiculeMotorCycleException(InfrastructureMessage.VehiculeDoNotExist);
        }
    }
}
