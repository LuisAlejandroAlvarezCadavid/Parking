using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IMotorCycleInsertRepository
    {
        Task<Vehicule> InsertMotorCycleAsync(Vehicule vehicule, CancellationToken cancellationToken);
    }
}
