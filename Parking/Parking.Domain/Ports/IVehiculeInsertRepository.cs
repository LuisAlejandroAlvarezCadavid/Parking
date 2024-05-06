using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IVehiculeInsertRepository
    {
        Task<Vehicule> InsertVehiculeAsync(Vehicule vehicule, CancellationToken cancellationToken);
    }
}
