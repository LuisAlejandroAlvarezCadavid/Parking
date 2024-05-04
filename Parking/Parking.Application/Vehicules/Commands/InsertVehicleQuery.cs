using MediatR;
using Parking.Domain.Entities;

namespace Parking.Application.Vehicules.Commands
{
    public record InsertVehicleQuery(string plate, string vehiculeType) : IRequest<Vehicule> { }
}
