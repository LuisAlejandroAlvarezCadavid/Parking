namespace Parking.Domain.Entities
{
    public class VehiculeMotorCycleValuesToPay : DomainEntity
    {
        double valueTOPayForADay;
        double valueTOPayForHour;
        string vehiculeType;

        public double ValueTOPayForADay
        {
            get => valueTOPayForADay;
            set
            {
                valueTOPayForADay = value <= 0 ? throw new ArgumentNullException(nameof(ValueTOPayForADay), "La propiedad no puede contener valores incorrectos") : value;
            }
        }

        public double ValueTOPayForHour
        {
            get => valueTOPayForHour;
            set
            {
                valueTOPayForHour = value <= 0 ? throw new ArgumentNullException(nameof(ValueTOPayForHour), "La propiedad no puede contener valores incorrectos") : value;
            }
        }

        public string VehiculeType
        {
            get => vehiculeType;
            set
            {
                vehiculeType = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(VehiculeType), "La propiedad no puede contener valores nulos") : value;

            }
        }
        public VehiculeMotorCycleValuesToPay(double valueTOPayForADay, double valueTOPayForHour, string vehiculeType) : base(Guid.NewGuid(), DateTime.Now, DateTime.Now)
        {
            ValueTOPayForADay = valueTOPayForADay;
            ValueTOPayForHour = valueTOPayForHour;
            VehiculeType = vehiculeType;
        }
    }
}
