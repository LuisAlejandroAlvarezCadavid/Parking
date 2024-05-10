using MediatR;
using Parking.Domain.Services.Implementations;

namespace Parking.Application.MotorCycles.Querys
{
    public class GetMotorCycleTimeToPayQueryHandler : IRequestHandler<GetMotorCycleTimeToPayQuery, double>
    {
        readonly ParkingStrategiService _parkingStrategiService;

        public GetMotorCycleTimeToPayQueryHandler(ParkingStrategiService parkingStrategiService)
        {
            _parkingStrategiService = parkingStrategiService;
        }

        public async Task<double> Handle(GetMotorCycleTimeToPayQuery request, CancellationToken cancellationToken)
        {
            return await _parkingStrategiService.GetValueToPayVehiculeOrMotorCycleAsync(request.plate, request.vehiculeType, cancellationToken);
        }
    }
}
