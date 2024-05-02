using MediatR;

namespace Parking.Application.Vehicules.Querys
{
    public class GetVehiculeTimeToPayQueryHandler : IRequestHandler<GetVehiculeTimeToPayQuery, double>
    {

        public GetVehiculeTimeToPayQueryHandler() { }

        public async Task<double> Handle(GetVehiculeTimeToPayQuery request, CancellationToken cancellationToken)
        {
            return 0.0;
        }
    }
}
