namespace Parking.Domain.Entities
{
    public class Vehicule : DomainEntity
    {

        string plate;
        DateTime enterTime;
        public DateTime? leaveTime { get; private set; }
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




        public Vehicule(Guid id, DateTime fechaCreacion, DateTime fechaModificacion, string plate, DateTime enterTime) : base(id, fechaCreacion, fechaModificacion)
        {
            Plate = plate;
            EnterTime = enterTime;
        }
    }
}
