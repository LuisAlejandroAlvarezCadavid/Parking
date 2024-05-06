using Parking.Domain.Entities;

namespace Parking.Domain.Services.Contractors
{
    public interface IVehicleStrategyService
    {
        public abstract string VehiculeType { get; set; }

        Task<TResult> InsertVehiculeAsync<TResult>(string plate, CancellationToken cancellationToken) where TResult : DomainEntity;
    }
}
