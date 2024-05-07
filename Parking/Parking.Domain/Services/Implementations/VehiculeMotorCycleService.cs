using Parking.Domain.Entities;
using Parking.Domain.Services.Contractors;

namespace Parking.Domain.Services.Implementations
{
    public abstract class VehiculeMotorCycleService : IVehicleStrategyService
    {
        public virtual string VehiculeType { get; set; } = "NO";

        public virtual async Task<TResult> InsertVehiculeOrMotorCycleAsync<TResult>(string plate, CancellationToken cancellationToken) where TResult : DomainEntity
        {
            return await Task.Run(() => (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now));
        }
    }
}
