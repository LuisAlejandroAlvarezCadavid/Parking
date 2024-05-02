using MediatR;

namespace Parking.Application.Vehicules.Querys
{
    public record GetVehiculeTimeToPayQuery(string vehiculeType) : IRequest<double> { }
}
