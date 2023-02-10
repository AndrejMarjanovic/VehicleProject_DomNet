using AutoMapper;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;

        public VehicleModelRepository(VehicleContext context, IMapper map)
        {
            mapper = map;
            _db = context;
        }
        public async Task<IVehicleModelModel> GetVehicleModelById(int id)
        {
            VehicleModel vehicleModel = _db.VehicleModel.Find(id);
            return mapper.Map<VehicleModelModel>(vehicleModel);
        }

        public async Task<IEnumerable<IVehicleModelModel>> GetVehicleModels()
        {
             return mapper.Map<IEnumerable<VehicleModelModel>>(_db.VehicleModel);
        }

        public async Task AddVehicleModel(IVehicleModelModel vehicleModelModel)
        {
            try
            {
               VehicleModel vehicleModel = mapper.Map<VehicleModel>(vehicleModelModel);
               await _db.VehicleModel.AddAsync(vehicleModel);
               await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }
        }

        public async Task EditVehicleModel(int id, IVehicleModelModel vehicleModelModel)
        {
            try
            {
                VehicleModel vehicleModel = mapper.Map<VehicleModel>(vehicleModelModel);
                vehicleModel.Id = id;
                _db.Entry(vehicleModel).State = EntityState.Modified;
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }
        }

        public async Task DeleteVehicleModel(int id)
        {
            try
            {
                VehicleModel vehicleModel = await _db.VehicleModel.FindAsync(id);
                _db.Remove(vehicleModel);
                await _db.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }

        }
    }
}
