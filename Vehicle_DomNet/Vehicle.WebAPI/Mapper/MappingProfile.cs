using AutoMapper;
using Vehicle.DAL.Entiteti;

namespace Vehicle.WebAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           CreateMap<VehicleMake, Vehicle.Model.VehicleMake>().ReverseMap();
           CreateMap<Vehicle.Model.VehicleMake, Models.VehicleMakeModel>().ReverseMap();
        }
    }
}
