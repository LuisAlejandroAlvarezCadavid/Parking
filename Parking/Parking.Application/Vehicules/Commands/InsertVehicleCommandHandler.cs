using AutoMapper;
using MediatR;
using Parking.Application.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.Services.Implementations;

namespace Parking.Application.Vehicules.Commands
{
    public class InsertVehicleCommandHandler : IRequestHandler<InsertVehicleCommand, VehiculeDto>
    {
        readonly ParkingStrategiService _parkingStrategiService;
        readonly IMapper _mapper;
        public InsertVehicleCommandHandler(ParkingStrategiService parkingStrategiService, IMapper mapper)
        {
            _parkingStrategiService = parkingStrategiService;
            _mapper = mapper;
        }

        public async Task<VehiculeDto> Handle(InsertVehicleCommand request, CancellationToken cancellationToken)
        {
            var vehiculeInsert = (Vehicule)await _parkingStrategiService.InsertVehiculeOrMotorCycleAsync(request.plate, request.vehiculeType, cancellationToken);
            return _mapper.Map<VehiculeDto>(vehiculeInsert);
        }
    }
}
