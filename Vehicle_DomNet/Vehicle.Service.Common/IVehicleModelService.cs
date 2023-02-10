using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IVehicleModelService
    {
        public Task<IVehicleModelModel> GetVehicleModelById(int id);
        public Task<IEnumerable<IVehicleModelModel>> GetVehicleModels();
        Task AddVehicleModel(IVehicleModelModel vehicleModel);
        Task EditVehicleModel(int id, IVehicleModelModel vehicleModel);
        Task DeleteVehicleModel(int id);
    }
}
