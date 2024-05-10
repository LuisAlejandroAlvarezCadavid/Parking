using Parking.Domain.Exceptions;
using Parking.Domain.Ports;
using Parking.Domain.Resources;
using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations.Vehicules
{
    [DomainService]
    public class VehiculeValueToPayService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = Texts.VEHICULE_TO_PAY;

        readonly IVehiculeRepository _vehiculeEnterRepository;
        readonly IBrockerSenderRepository _brockerSenderRepository;
        readonly IVehiculeMotorCycleValuesToPayRepository _vehiculeMotorCycleValuesToPayRepository;


        public VehiculeValueToPayService(IVehiculeRepository vehiculeEnterRepository, IBrockerSenderRepository brockerSenderRepository, IVehiculeMotorCycleValuesToPayRepository vehiculeMotorCycleValuesToPayRepository)
        {
            _vehiculeEnterRepository = vehiculeEnterRepository;
            _brockerSenderRepository = brockerSenderRepository;
            _vehiculeMotorCycleValuesToPayRepository = vehiculeMotorCycleValuesToPayRepository;
        }

        public override async Task<double> GetValueToPayVehiculeOrMotorCycleAsync(string plate, CancellationToken cancellationToken)
        {
            var vehicule = await _vehiculeEnterRepository.GetVehiculeAsync(plate, cancellationToken) ?? throw new VehiculeMotorCycleException(DomainMessages.VehiculeDoNotExist);
            var veluesTOPayFromDataBase = await _vehiculeMotorCycleValuesToPayRepository.GetVehiculeMotorCycleValuesTOPay(Enums.VehiculeType.VEHICULE.ToString(), cancellationToken)
                                          ?? throw new VehiculeMotorCycleException(DomainMessages.VehiculeTypeDoNotExist);
            var valueTOpay = SharedTasks.CalculateValueToPay(vehicule.EnterTime, DateTime.Now.AddHours(10), veluesTOPayFromDataBase.ValueTOPayForHour, veluesTOPayFromDataBase.ValueTOPayForADay);
            SharedTasks.SendBrockerMessge(_brockerSenderRepository, plate, string.Format(DomainMessages.VehiculeValueTOPay, plate));
            return valueTOpay;

        }
    }
}
