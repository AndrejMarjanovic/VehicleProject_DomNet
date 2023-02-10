using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository.Common;
using Vehicle.Service.Common;

namespace Vehicle.Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private IVehicleMakeRepository VMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            VMakeRepository = vehicleMakeRepository;
        }
        public async Task<IVehicleMakeModel> GetVehicleMakeById(int id)
        {
            IVehicleMakeModel vehicleMake = await VMakeRepository.GetVehicleMakeById(id);
            return vehicleMake;
        }

        public async Task<IEnumerable<IVehicleMakeModel>> GetVehicleMakes()
        {
            return await VMakeRepository.GetVehicleMakes();
        }

        public async Task AddVehicleMake(IVehicleMakeModel vehicleMakeModel)
        {
            try
            {
               await VMakeRepository.AddVehicleMake(vehicleMakeModel);

            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed",ex);
            }
        }

        public async Task EditVehicleMake(int id, IVehicleMakeModel vehicleMakeModel)
        {
            try
            {
                await VMakeRepository.EditVehicleMake(id, vehicleMakeModel);

            }
            catch (Exception ex)
            {
                throw new Exception("Operation failed", ex);
            }
        }

        public async Task DeleteVehicleMake(int id)
        {
            try
            {
                await VMakeRepository.DeleteVehicleMake(id);
            }
            catch(Exception ex)
            {
                throw new Exception("Operation failed", ex);
            }
        }
    }
}
