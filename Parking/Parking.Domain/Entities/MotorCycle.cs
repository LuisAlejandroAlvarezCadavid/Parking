namespace Parking.Domain.Entities
{
    public class MotorCycle : DomainEntity
    {
        string plate;
        DateTime enterTime;
        DateTime leaveTime;
        public string Plate
        {
            get => plate;
            set
            {
                if (string.IsNullOrEmpty(plate))
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

        public DateTime LeaveTime
        {
            get => leaveTime;
            set
            {
                if (value.Ticks == 0)
                {
                    throw new ArgumentNullException(nameof(LeaveTime), "La propiedad {0} no puede contener valores nulos");
                }
                leaveTime = value;
            }
        }


        public MotorCycle(Guid id, DateTime fechaCreacion, DateTime fechaModificacion, string plate, DateTime enterTime, DateTime leaveTime) : base(id, fechaCreacion, fechaModificacion)
        {
            Plate = plate;
            EnterTime = enterTime;
            LeaveTime = leaveTime;
        }

    }
}
