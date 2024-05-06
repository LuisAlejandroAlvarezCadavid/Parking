using Parking.Domain.Entities;

namespace Parking.Domain.Services.Contractors
{
    public interface IVehicleEnterStrategyService
    {
        public abstract string VehiculeType { get; set; }

        Task<TResult> InsertEnterVehiculeAsync<TResult>(string plate, CancellationToken cancellationToken) where TResult : DomainEntity;
    }
}
