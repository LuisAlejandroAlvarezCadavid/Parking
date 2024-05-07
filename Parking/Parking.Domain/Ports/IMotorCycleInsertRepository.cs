using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IMotorCycleInsertRepository
    {
        Task<MotorCycle> InsertMotorCycleAsync(MotorCycle vehicule, CancellationToken cancellationToken);
    }
}
