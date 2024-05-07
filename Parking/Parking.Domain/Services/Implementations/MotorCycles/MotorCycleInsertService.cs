using Parking.Domain.Entities;
using Parking.Domain.Ports;
using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations.MotorCycles
{
    [DomainService]
    public class MotorCycleInsertService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = Texts.MOTOR_CYCLE;

        readonly IMotorCycleRepository _motorCycleInsertRepository;
        readonly IBrockerSenderRepository _brockerSenderRepository;

        public MotorCycleInsertService(IMotorCycleRepository motorCycleInsertRepository, IBrockerSenderRepository brockerSenderRepository)
        {
            _motorCycleInsertRepository = motorCycleInsertRepository;
            _brockerSenderRepository = brockerSenderRepository;
        }

        public override async Task<TResult> InsertVehiculeOrMotorCycleAsync<TResult>(string plate, CancellationToken cancellationToken)
        {
            var motorCycle = new MotorCycle(Guid.NewGuid(), DateTime.Now, DateTime.Now, plate, DateTime.Now);
            var result = await _motorCycleInsertRepository.InsertMotorCycleAsync(motorCycle, cancellationToken);
            if (result != null)
            {
                SharedTasks.SendBrockerMessge(_brockerSenderRepository, plate);
                return (TResult)(DomainEntity)result;
            }
            return (TResult)new DomainEntity(Guid.NewGuid(), DateTime.Now, DateTime.Now);
        }
    }
}
