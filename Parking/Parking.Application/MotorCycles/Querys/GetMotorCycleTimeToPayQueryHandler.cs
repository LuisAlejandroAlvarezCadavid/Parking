using MediatR;

namespace Parking.Application.MotorCycles.Querys
{
    public class GetMotorCycleTimeToPayQueryHandler : IRequestHandler<GetMotorCycleTimeToPayQuery, double>
    {

        public GetMotorCycleTimeToPayQueryHandler() { }

        public async Task<double> Handle(GetMotorCycleTimeToPayQuery request, CancellationToken cancellationToken)
        {
            return 0.0;
        }
    }
}
