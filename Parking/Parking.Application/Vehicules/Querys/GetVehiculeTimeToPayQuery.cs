using MediatR;

namespace Parking.Application.Vehicules.Querys
{
    public record GetVehiculeTimeToPayQuery(string plate, string vehiculeType) : IRequest<double> { }
}
