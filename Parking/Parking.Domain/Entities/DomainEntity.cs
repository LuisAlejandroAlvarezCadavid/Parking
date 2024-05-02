namespace Parking.Domain.Entities
{
    public class DomainEntity
    {
        Guid id;
        DateTime fechaCreacion;
        DateTime fechaModificacion;
        public Guid Id
        {
            get => id;
            set
            {
                if (value == Guid.Empty)
                {
                    throw new ArgumentNullException(nameof(Id), "La propiedad {0} no puede contener valores nulos");
                }
                id = value;
            }
        }

        public DateTime FechaCreacion
        {
            get => fechaCreacion;

            set
            {
                if (value.Ticks == 0)
                {
                    throw new ArgumentNullException(nameof(FechaCreacion), "La propiedad {0} no puede contener valores nulos");

                }
                fechaCreacion = value;
            }
        }

        public DateTime FechaModificacion
        {
            get => fechaModificacion;

            set
            {
                if (value.Ticks == 0)
                {
                    throw new ArgumentNullException(nameof(FechaModificacion), "La propiedad {0} no puede contener valores nulos");

                }
                fechaModificacion = value;
            }
        }

        public DomainEntity(Guid id, DateTime fechaCreacion, DateTime fechaModificacion)
        {
            Id = id;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
        }
    }
}
