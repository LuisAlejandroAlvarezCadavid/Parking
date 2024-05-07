using MediatR;
using Parking.Application.Dtos;

namespace Parking.Application.Vehicules.Commands
{
    public record InsertVehicleCommand(string plate, string vehiculeType) : IRequest<VehiculeDto> { }
}
