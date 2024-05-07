using AutoMapper;
using MediatR;
using Parking.Application.Dtos;
using Parking.Domain.Entities;
using Parking.Domain.Services.Implementations;

namespace Parking.Application.MotorCycles.Commands
{
    public class InsertMotorCycleCommandHandler : IRequestHandler<InsertMotorCycleCommand, VehiculeDto>
    {
        readonly ParkingStrategiService _parkingStrategiService;
        readonly IMapper _mapper;

        public InsertMotorCycleCommandHandler(ParkingStrategiService strategiService, IMapper mapper)
        {
            _parkingStrategiService = strategiService;
            _mapper = mapper;
        }

        public async Task<VehiculeDto> Handle(InsertMotorCycleCommand request, CancellationToken cancellationToken)
        {
            var vehiculeInsert = (MotorCycle)await _parkingStrategiService.InsertVehiculeOrMotorCycleAsync(request.plate, request.vehiculeType, cancellationToken);
            return _mapper.Map<VehiculeDto>(vehiculeInsert);
        }
    }
}
