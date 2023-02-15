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
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private readonly VehicleContext _db;
        private readonly IMapper mapper;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleMakeRepository(VehicleContext context, IMapper map, IUnitOfWork unitOfWork)
        {
            mapper = map;
            _db = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<IVehicleMakeModel> GetVehicleMakeById(int id)
        {
            VehicleMake vehicleMake = _db.VehicleMake.Find(id);
            return mapper.Map<VehicleMakeModel>(vehicleMake);
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
               await _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }
        }

        public async Task EditVehicleMake(int id, IVehicleMakeModel vehicleMakeModel)
        {
            try
            {
                VehicleMake vehicleMake = mapper.Map<VehicleMake>(vehicleMakeModel);
                vehicleMake.Id = id;
                _db.Entry(vehicleMake).State = EntityState.Modified;
                await _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }
        }

        public async Task DeleteVehicleMake(int id)
        {
            try
            {
                VehicleMake vehicleMake = await _db.VehicleMake.FindAsync(id);
                _db.Remove(vehicleMake);
                await _unitOfWork.Save();

            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed.", ex);
            }

        }

        public async Task<IEnumerable<IVehicleMakeModel>> GetFilteredVehicleMakes(Filtering filter, Paging paging, Sorting sorting)
        {

            var vMakeList = await _db.VehicleMake.ToListAsync();
            var vehicleMakes = mapper.Map<IEnumerable<VehicleMakeModel>>(vMakeList).AsQueryable();

            if (filter.Filter())
            {
                vehicleMakes = vehicleMakes.Where(n => n.Name.ToLower().Contains(filter.FilterString) || n.Abrv.ToLower().Contains(filter.FilterString));
            }
            
            switch (sorting.SortBy)
            {
                case "name":
                    if (!sorting.IsDesending)
                    {
                        vehicleMakes = vehicleMakes.OrderBy(x => x.Name);
                    }
                    else
                    {
                        vehicleMakes = vehicleMakes.OrderByDescending(x => x.Name);
                    }
                    break;

                case "abrv":
                    if (!sorting.IsDesending)
                    {
                        vehicleMakes = vehicleMakes.OrderBy(x => x.Abrv);
                    }
                    else
                    {
                        vehicleMakes = vehicleMakes.OrderByDescending(x => x.Abrv);
                    }
                    break;

                default:
                    if (!sorting.IsDesending)
                    {
                        vehicleMakes = vehicleMakes.OrderBy(x => x.Id);
                    }
                    else
                    {
                        vehicleMakes = vehicleMakes.OrderByDescending(x => x.Id); 
                    }
                    break;
            }

            return vehicleMakes.Skip(paging.ItemsToSkip).Take(paging.PageSize);
        }

    }
}
