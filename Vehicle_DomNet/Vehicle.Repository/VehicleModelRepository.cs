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
using Vehicle.Common;

namespace Vehicle.Repository
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }
        public async Task<IVehicleModelModel> GetVehicleModelById(int id)
        {
            VehicleModel vehicleModel = _db.VehicleModel.Find(id);
            return mapper.Map<VehicleModelModel>(vehicleModel);
        }

        public async Task<IEnumerable<IVehicleModelModel>> GetVehicleModels()
        {
             return mapper.Map<IEnumerable<VehicleModelModel>>(_db.VehicleModel.Include(x=>x.VehicleMake));
        }

        public async Task AddVehicleModel(IVehicleModelModel vehicleModelModel)
        {
            try
            {
               VehicleModel vehicleModel = mapper.Map<VehicleModel>(vehicleModelModel);
               await _db.VehicleModel.AddAsync(vehicleModel);
               await _unitOfWork.Save();
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
                await _unitOfWork.Save();
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
                await _unitOfWork.Save();

            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }

        }

        public async Task<IEnumerable<IVehicleModelModel>> GetFilteredVehicleModels(string filter, Paging paging, Sorting sorting)
        {

            var vModelList = await _db.VehicleModel.Include(m=>m.VehicleMake).ToListAsync();
            var vehicleModels = mapper.Map<IEnumerable<VehicleModelModel>>(vModelList).AsQueryable();

            if (!string.IsNullOrEmpty(filter))
            {
                vehicleModels = vehicleModels.Where(m => m.Name.ToLower().Contains(filter.ToLower()) 
                || m.Abrv.ToLower().Contains(filter.ToLower()) 
                || m.VehicleMake.Name.ToLower().Contains(filter.ToLower()));
            }

            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        vehicleModels = vehicleModels.OrderBy(x => x.Name);
                    }
                    else
                    {
                        vehicleModels = vehicleModels.OrderByDescending(x => x.Name);
                    }
                    break;

                case "make":
                    if (!sorting.IsDesending)
                    {
                        vehicleModels = vehicleModels.OrderBy(x => x.VehicleMake.Name);
                    }
                    else
                    {
                        vehicleModels = vehicleModels.OrderByDescending(x => x.VehicleMake.Name);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        vehicleModels = vehicleModels.OrderBy(x => x.Id);
                    }
                    else
                    {
                        vehicleModels = vehicleModels.OrderByDescending(x => x.Id);
                    }
                    break;
            }

            return vehicleModels.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }
    }
}
