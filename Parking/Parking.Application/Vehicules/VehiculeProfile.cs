using AutoMapper;
using Parking.Application.Dtos;
using Parking.Domain.Entities;

namespace Parking.Application.Vehicules
{
    public sealed class VehiculeProfile : Profile
    {
        public VehiculeProfile()
        {
            CreateMap<Vehicule, VehiculeDto>();
        }

    }
}
