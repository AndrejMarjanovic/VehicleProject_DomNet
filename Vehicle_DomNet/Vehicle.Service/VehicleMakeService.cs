using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<IVehicleMake> GetVehicleMakeById(int id)
        {
            IVehicleMake make = await VMakeRepository.GetVehicleMakeById(id);
            return make;
        }
    }
}
