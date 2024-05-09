namespace Parking.Domain.Exceptions
{
    public class VehiculeMotorCycleException : Exception
    {
        public VehiculeMotorCycleException() : base() { }

        public VehiculeMotorCycleException(string message) : base(message) { }
    }
}
