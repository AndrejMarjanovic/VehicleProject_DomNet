using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;

namespace Vehicle.Repository
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;

        public VehicleMakeRepository(VehicleContext context, IMapper map)
        {
            mapper = map;
            _db = context;
        }
        public async Task<IVehicleMake> GetVehicleMakeById(int id)
        {
            var entity = _db.VehicleMake.Find(id);
            return mapper.Map<VehicleMake>(entity);
        }
    }
}
