using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleModelService : IVehicleModelService
    {
        private IVehicleModelRepository VModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            VModelRepository = vehicleModelRepository;
        }
        public async Task<IVehicleModelModel> GetVehicleModelById(int id)
        {
            IVehicleModelModel vehicleModel = await VModelRepository.GetVehicleModelById(id);
            return vehicleModel;
        }

        public async Task<IEnumerable<IVehicleModelModel>> GetVehicleModels()
        {
            return await VModelRepository.GetVehicleModels();
        }

        public async Task<IEnumerable<IVehicleModelModel>> GetFilteredVehicleModels(Filtering filter, Paging paging, Sorting sorting)
        {
            return await VModelRepository.GetFilteredVehicleModels(filter, paging, sorting);
        }

        public async Task AddVehicleModel(IVehicleModelModel vehicleModelModel)
        {
            try
            {
               await VModelRepository.AddVehicleModel(vehicleModelModel);

            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed",ex);
            }
        }

        public async Task EditVehicleModel(int id, IVehicleModelModel vehicleModelModel)
        {
            try
            {
                await VModelRepository.EditVehicleModel(id, vehicleModelModel);

            }
            catch (Exception ex)
            {
                throw new Exception("Operation failed", ex);
            }
        }

        public async Task DeleteVehicleModel(int id)
        {
            try
            {
                await VModelRepository.DeleteVehicleModel(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed", ex);
            }
        }
    }
}
