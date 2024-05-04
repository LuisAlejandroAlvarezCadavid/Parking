using AutoMapper;
using Parking.Application.Dtos;
using Parking.Domain.Entities;

namespace Parking.Application.MotorCycles
{
    public class MotorCyclesProfile : Profile
    {
        public MotorCyclesProfile()
        {
            CreateMap<MotorCycle, VehiculeDto>();
        }
    }
}
