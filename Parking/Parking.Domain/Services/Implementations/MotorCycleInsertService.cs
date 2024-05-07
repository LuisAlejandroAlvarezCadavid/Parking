using Parking.Domain.Entities;
using Parking.Domain.Ports;

namespace Parking.Domain.Services.Implementations
{
    [DomainService]
    public class MotorCycleInsertService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = "MT";

        readonly IMotorCycleInsertRepository _motorCycleInsertRepository;

        public MotorCycleInsertService(IMotorCycleInsertRepository motorCycleInsertRepository)
        {
            _motorCycleInsertRepository = motorCycleInsertRepository;
        }

        public override async Task<TResult> InsertVehiculeOrMotorCycleAsync<TResult>(string plate, CancellationToken cancellationToken)
        {
            var vehicule = new MotorCycle(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
            var result = await _motorCycleInsertRepository.InsertMotorCycleAsync(vehicule, cancellationToken);
            if (result != null)
            {
                return (TResult)(DomainEntity)result;
            }
            return (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now);
        }
    }
}
