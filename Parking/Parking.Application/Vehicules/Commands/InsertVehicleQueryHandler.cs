using AutoMapper;
using MediatR;
using Parking.Application.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.Services.Implementations;

namespace Parking.Application.Vehicules.Commands
{
    public class InsertVehicleQueryHandler : IRequestHandler<InsertVehicleQuery, VehiculeDto>
    {
        readonly ParkingStrategiService _parkingStrategiService;
        readonly IMapper _mapper;
        public InsertVehicleQueryHandler(ParkingStrategiService parkingStrategiService, IMapper mapper)
        {
            _parkingStrategiService = parkingStrategiService;
            _mapper = mapper;
        }

        public async Task<VehiculeDto> Handle(InsertVehicleQuery request, CancellationToken cancellationToken)
        {
            var vehiculeInsert = (Vehicule)await _parkingStrategiService.InsertVehiculeOrMotorCycleAsync(request.plate, request.vehiculeType, cancellationToken);
            return _mapper.Map<VehiculeDto>(vehiculeInsert);
        }
    }
}
