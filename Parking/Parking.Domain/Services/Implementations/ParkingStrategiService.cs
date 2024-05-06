using Parking.Domain.Entities;
using Parking.Domain.Services.Contractors;

namespace Parking.Domain.Services.Implementations
{
    [DomainService]
    public class ParkingStrategiService
    {

        readonly IEnumerable<IVehicleEnterStrategyService> _vehicleEnterStrategyService;

        public ParkingStrategiService(IEnumerable<IVehicleEnterStrategyService> vehicleEnterStrategyService)
        {
            _vehicleEnterStrategyService = vehicleEnterStrategyService;
        }

        public async Task<DomainEntity> InsertEnterVehiculeAsync(string plate, string vehiculeType, CancellationToken cancellationToken)
        {
            var strategy = _vehicleEnterStrategyService.FirstOrDefault(strategy => strategy.VehiculeType == vehiculeType);
            return await strategy!.InsertEnterVehiculeAsync<DomainEntity>(plate, cancellationToken);
        }
    }
}
