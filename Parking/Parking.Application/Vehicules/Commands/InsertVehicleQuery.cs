using MediatR;
using Parking.Application.Dtos;

namespace Parking.Application.Vehicules.Commands
{
    public record InsertVehicleQuery(string plate, string vehiculeType) : IRequest<VehiculeDto> { }
}
