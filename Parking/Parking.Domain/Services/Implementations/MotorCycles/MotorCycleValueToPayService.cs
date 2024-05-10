using Parking.Domain.Exceptions;
using Parking.Domain.Ports;
using Parking.Domain.Resources;
using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations.MotorCycles
{
    [DomainService]
    public class MotorCycleValueToPayService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = Texts.MOTOR_CYCLE_TO_PAY;

        readonly IMotorCycleRepository _motorCycleRepository;
        readonly IBrockerSenderRepository _brockerSenderRepository;
        readonly IVehiculeMotorCycleValuesToPayRepository _vehiculeMotorCycleValuesToPayRepository;

        public MotorCycleValueToPayService(IMotorCycleRepository motorCycleRepository, IBrockerSenderRepository brockerSenderRepository, IVehiculeMotorCycleValuesToPayRepository vehiculeMotorCycleValuesToPayRepository)
        {
            _motorCycleRepository = motorCycleRepository;
            _brockerSenderRepository = brockerSenderRepository;
            _vehiculeMotorCycleValuesToPayRepository = vehiculeMotorCycleValuesToPayRepository;
        }

        public override async Task<double> GetValueToPayVehiculeOrMotorCycleAsync(string plate, CancellationToken cancellationToken)
        {
            var motorCycle = await _motorCycleRepository.GetMotorCycleAsync(plate, cancellationToken) ?? throw new VehiculeMotorCycleException(DomainMessages.VehiculeDoNotExist);
            var veluesTOPayFromDataBase = await _vehiculeMotorCycleValuesToPayRepository.GetVehiculeMotorCycleValuesTOPay(Enums.VehiculeType.MOTOR_CYCLE.ToString(), cancellationToken)
                                          ?? throw new VehiculeMotorCycleException(DomainMessages.VehiculeTypeDoNotExist);
            var valueTOpay = SharedTasks.CalculateValueToPay(motorCycle.EnterTime, DateTime.Now.AddHours(10), veluesTOPayFromDataBase.ValueTOPayForHour, veluesTOPayFromDataBase.ValueTOPayForADay);
            SharedTasks.SendBrockerMessge(_brockerSenderRepository, plate, string.Format(DomainMessages.VehiculeValueTOPay, plate), valueTOpay);
            return valueTOpay;
        }
    }
}
