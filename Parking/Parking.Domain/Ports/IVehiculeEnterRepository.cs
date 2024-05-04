using Parking.Domain.Entities;

namespace Parking.Domain.Ports
{
    public interface IVehiculeEnterRepository
    {
        Task<Vehicule> EnterVehiculeAsync(Vehicule vehicule, CancellationToken cancellationToken);
    }
}
