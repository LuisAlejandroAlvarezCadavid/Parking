using Parking.Domain.Ports;
using Parking.Infrastructure.DataContext;

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
    }
}
