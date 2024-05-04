using MediatR;

namespace Parking.Application.MotorCycles.Querys
{
    public record GetMotorCycleTimeToPayQuery(string plate, string vehiculeType) : IRequest<double> { }
}
