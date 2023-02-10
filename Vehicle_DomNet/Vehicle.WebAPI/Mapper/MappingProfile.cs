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
            CreateMap<VehicleMakeModel, VehicleMakeGetModel>().ReverseMap();
            CreateMap<VehicleMakeModel, VehicleMakePostModel>().ReverseMap();

            CreateMap<VehicleModel, VehicleModelModel>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModelGetModel>().ReverseMap();
            CreateMap<VehicleModelModel, VehicleModelPostModel>().ReverseMap();
        }
    }
}
