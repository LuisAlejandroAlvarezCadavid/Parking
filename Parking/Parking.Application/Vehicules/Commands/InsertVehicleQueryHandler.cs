using MediatR;
using Parking.Domain.Entities;

namespace Parking.Application.Vehicules.Commands
{
    public class InsertVehicleQueryHandler : IRequestHandler<InsertVehicleQuery, Vehicule>
    {

        public InsertVehicleQueryHandler()
        {
        }
    }
}
