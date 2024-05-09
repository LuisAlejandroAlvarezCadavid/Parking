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
                plate = string.IsNullOrEmpty(value) ? throw new ArgumentNullException(nameof(Plate), "La propiedad {0} no puede contener valores nulos") : value;
            }
        }

        public DateTime EnterTime
        {
            get => enterTime;
            set
            {
                enterTime = value.Ticks == 0 ? throw new ArgumentNullException(nameof(EnterTime), "La feha debe contener un valor correcto") : value;
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
