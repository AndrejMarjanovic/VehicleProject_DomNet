using AutoMapper;
using Vehicle.DAL.Entiteti;
using Vehicle.Model;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<VehicleMake, VehicleMakeModel>().ReverseMap();
           CreateMap<VehicleMakeModel, VehicleMakeRestModel>().ReverseMap();
        }
    }
}
