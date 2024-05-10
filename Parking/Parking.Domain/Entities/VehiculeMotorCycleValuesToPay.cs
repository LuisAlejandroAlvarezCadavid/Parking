using Parking.Domain.Resources;

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
                valueTOPayForADay = value <= 0 ? throw new ArgumentNullException(nameof(ValueTOPayForADay), DomainMessages.ValueMinorThanZero) : value;
            }
        }

        public double ValueTOPayForHour
        {
            get => valueTOPayForHour;
            set
            {
                valueTOPayForHour = value <= 0 ? throw new ArgumentNullException(nameof(ValueTOPayForHour), DomainMessages.ValueMinorThanZero) : value;
            }
        }

        public string VehiculeType
        {
            get => vehiculeType;
            set
            {
                vehiculeType = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(VehiculeType), string.Format(DomainMessages.NullValueProperty, nameof(VehiculeType))) : value;

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
