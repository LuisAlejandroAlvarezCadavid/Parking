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

        public async Task<TResult> InsertEnterVehiculeAsync<TResult>(string plate, string vehiculeType)
        {
            var strategy = _vehicleEnterStrategyService.FirstOrDefault(strategy => strategy.VehiculeType == vehiculeType);
            return await strategy.InsertEnterVehiculeAsync<TResult>()
        }
    }
}
