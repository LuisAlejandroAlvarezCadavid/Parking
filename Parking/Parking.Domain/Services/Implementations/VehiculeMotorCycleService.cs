using Parking.Domain.Entities;
using Parking.Domain.Services.Contractors;
using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations
{
    public abstract class VehiculeMotorCycleService : IVehicleStrategyService
    {
        public virtual string VehiculeType { get; set; } = Texts.NO_VEHICULE;

        public virtual async Task<TResult> InsertVehiculeOrMotorCycleAsync<TResult>(string plate, CancellationToken cancellationToken) where TResult : DomainEntity
        {
            return await Task.Run(() => (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now));
        }

        public virtual async Task<double> GetValueToPayVehiculeOrMotorCycleAsync(string plate, CancellationToken cancellationToken)
        {
            return await Task.Run(() => 0.0);
        }
    }
}
