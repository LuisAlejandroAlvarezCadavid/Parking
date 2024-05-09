namespace Parking.Domain.Entities
{
    public class MotorCycle : DomainEntity
    {
        string plate;
        DateTime enterTime;
        public DateTime? LeaveTime { get; private set; }
        public int? ValuePay { get; private set; }
        public string Plate
        {
            get => plate;
            set
            {
                plate = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(Plate), "La propiedad no puede contener valores nulos") : value;
            }
        }

        public DateTime EnterTime
        {
            get => enterTime;
            set
            {
                enterTime = value.Ticks == 0 ? throw new ArgumentNullException(nameof(EnterTime), "La propiedad no puede contener valores nulos") : value;
            }
        }




        public MotorCycle(Guid id, DateTime fechaCreacion, DateTime fechaModificacion, string plate, DateTime enterTime) : base(id, fechaCreacion, fechaModificacion)
        {
            Plate = plate;
            EnterTime = enterTime;

        }

        public void SetValuePay(int value) => ValuePay = value;
        public void SetLeaveTime(DateTime leaveTime) => LeaveTime = leaveTime;

    }
}
