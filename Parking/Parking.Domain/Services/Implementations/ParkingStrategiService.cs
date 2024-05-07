using Parking.Domain.Entities;
using Parking.Domain.Services.Contractors;

namespace Parking.Domain.Services.Implementations
{
    [DomainService]
    public class ParkingStrategiService
    {

        readonly IEnumerable<IVehicleStrategyService> _vehicleEnterStrategyService;

        public ParkingStrategiService(IEnumerable<IVehicleStrategyService> vehicleEnterStrategyService)
        {
            _vehicleEnterStrategyService = vehicleEnterStrategyService;
        }

        public async Task<DomainEntity> InsertVehiculeOrMotorCycleAsync(string plate, string vehiculeType, CancellationToken cancellationToken)
        {
            var strategy = _vehicleEnterStrategyService.FirstOrDefault(strategy => strategy.VehiculeType == vehiculeType);
            return await strategy!.InsertVehiculeOrMotorCycleAsync<DomainEntity>(plate, cancellationToken);
        }

        public async Task<double> GetValueToPayVehiculeOrMotorCycleAsync(string plate, string vehiculeType, CancellationToken cancellationToken)
        {
            var strategy = _vehicleEnterStrategyService.FirstOrDefault(strategy => strategy.VehiculeType == vehiculeType);
            return await strategy!.GetValueToPayVehiculeOrMotorCycleAsync(plate, cancellationToken);
        }
    }
}
