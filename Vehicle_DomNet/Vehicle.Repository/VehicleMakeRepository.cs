using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL;
using Vehicle.DAL.Entiteti;
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
        public async Task<IVehicleMakeModel> GetVehicleMakeById(int id)
        {
            var entity = _db.VehicleMake.Find(id);
            return mapper.Map<VehicleMakeModel>(entity);
        }

        public async Task<IEnumerable<IVehicleMakeModel>> GetVehicleMakes()
        {
             return mapper.Map<IEnumerable<VehicleMakeModel>>(_db.VehicleMake);
        }

        public async Task AddVehicleMake(IVehicleMakeModel vehicleMakeModel)
        {
            try
            {
                VehicleMake vehicleMake = mapper.Map<VehicleMake>(vehicleMakeModel);
               await _db.VehicleMake.AddAsync(vehicleMake);
               await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }
        }
    }
}
