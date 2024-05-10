using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IMotorCycleRepository
    {
        Task<MotorCycle> InsertMotorCycleAsync(MotorCycle vehicule, CancellationToken cancellationToken);

        Task<MotorCycle> GetMotorCycleAsync(string plate, CancellationToken cancellationToken);
    }
}
