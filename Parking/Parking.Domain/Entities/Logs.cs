namespace Parking.Domain.Entities
{
    public class Logs : DomainEntity
    {
        string plate;
        DateTime enterTime;
        public string? Observation { get; set; } = default!;
        public int? ValuePay { get; set; }
        public DateTime? LeaveTime { get; set; }
        public string Plate
        {
            get => plate;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(Plate), "La propiedad {0} no puede contener valores nulos");
                }
                plate = value;
            }
        }

        public DateTime EnterTime
        {
            get => enterTime;
            set
            {
                if (value.Ticks == 0)
                {
                    throw new ArgumentNullException(nameof(EnterTime), "La propiedad {0} no puede contener valores nulos");
                }
                enterTime = value;
            }
        }

        public Logs(Guid id, DateTime fechaCreacion, DateTime fechaModificacion, string plate, DateTime enterTime) : base(id, fechaCreacion, fechaModificacion)
        {
            Plate = plate;
            EnterTime = enterTime;
        }

        public void SetValuePay(int value) => ValuePay = value;
        public void SetLeaveTime(DateTime leaveTime) => LeaveTime = leaveTime;
    }
}
