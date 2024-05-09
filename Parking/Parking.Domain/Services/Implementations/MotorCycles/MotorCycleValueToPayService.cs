using Parking.Domain.Structs;

namespace Parking.Domain.Services.Implementations.MotorCycles
{
    public class MotorCycleValueToPayService : VehiculeMotorCycleService
    {
        public override string VehiculeType { get; set; } = Texts.VEHICULE_TO_PAY;
    }
}
