using Parking.Domain.Entities;
using Parking.Domain.Ports;

namespace Parking.Domain.Services.Implementations
{
    [DomainService]
    public class VehiculeService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = "VH";

        readonly IVehiculeEnterRepository _vehiculeEnterRepository;

        public VehiculeService(IVehiculeEnterRepository vehiculeEnterRepository)
        {
            _vehiculeEnterRepository = vehiculeEnterRepository;
        }

        public override async Task<TResult> InsertEnterVehiculeAsync<TResult>(string plate, CancellationToken cancellationToken)
        {
            var vehicule = new Vehicule(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
            var result = await _vehiculeEnterRepository.EnterVehiculeAsync(vehicule, cancellationToken);
            if (result != null)
            {
                return (TResult)(DomainEntity)result;
            }
            return (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now);
        }
    }
}
