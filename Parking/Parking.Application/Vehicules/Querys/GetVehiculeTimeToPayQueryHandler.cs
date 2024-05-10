using MediatR;
using Parking.Domain.Services.Implementations;

namespace Parking.Application.Vehicules.Querys
{
    public class GetVehiculeTimeToPayQueryHandler : IRequestHandler<GetVehiculeTimeToPayQuery, double>
    {
        readonly ParkingStrategiService _parkingStrategiService;

        public GetVehiculeTimeToPayQueryHandler(ParkingStrategiService parkingStrategiService)
        {
            _parkingStrategiService = parkingStrategiService;
        }

        public async Task<double> Handle(GetVehiculeTimeToPayQuery request, CancellationToken cancellationToken)
        {
            return await _parkingStrategiService.GetValueToPayVehiculeOrMotorCycleAsync(request.plate, request.vehiculeType, cancellationToken);
        }
    }
}
