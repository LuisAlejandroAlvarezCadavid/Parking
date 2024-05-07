using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IVehiculeRepository
    {
        Task<Vehicule> InsertVehiculeAsync(Vehicule vehicule, CancellationToken cancellationToken);
    }
}
