using MediatR;
using Parking.Application.Dtos;

namespace Parking.Application.MotorCycles.Commands
{
    public record InsertMotorCycleCommand(string plate, string vehiculeType) : IRequest<VehiculeDto> { }
}
