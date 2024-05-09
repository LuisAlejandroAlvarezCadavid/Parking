using Parking.Domain.Exceptions;
using Parking.Domain.Ports;
using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations.Vehicules
{
    [DomainService]
    public class VehiculeValueToPayService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = Texts.VEHICULE_TO_PAY;

        readonly IVehiculeRepository _vehiculeEnterRepository;
        readonly IBrockerSenderRepository _brockerSenderRepository;

        public VehiculeValueToPayService(IVehiculeRepository vehiculeEnterRepository, IBrockerSenderRepository brockerSenderRepository)
        {
            _vehiculeEnterRepository = vehiculeEnterRepository;
            _brockerSenderRepository = brockerSenderRepository;
        }

        public override async Task<double> GetValueToPayVehiculeOrMotorCycleAsync(string plate, CancellationToken cancellationToken)
        {
            var vehicule = await _vehiculeEnterRepository.GetVehiculeAsync(plate, cancellationToken);
            if (vehicule == null)
            {
                throw new VehiculeMotorCycleException("El vehiculo o moto solicitada no existe");
            }
            var valueToPay = SharedTasks.CalculateValueToPay(vehicule.EnterTime, DateTime.Now, 0.0, 0.0);
            return 0.0;
        }
    }
}
