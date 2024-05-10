using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IVehiculeMotorCycleValuesToPayRepository
    {
        Task<VehiculeMotorCycleValuesToPay> GetVehiculeMotorCycleValuesTOPay(string vehiculeType, CancellationToken cancellationToken);
    }
}
