using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Service.Common
{
    public interface IVehicleMakeService
    {
        public Task<IVehicleMakeModel> GetVehicleMakeById(int id);
        public Task<IEnumerable<IVehicleMakeModel>> GetVehicleMakes();
        Task AddVehicleMake(IVehicleMakeModel vehicleMake);
        Task EditVehicleMake(int id, IVehicleMakeModel vehicleMake);
        Task DeleteVehicleMake(int id);
        Task<IEnumerable<IVehicleMakeModel>> GetFilteredVehicleMakes(Filtering filter, Paging paging, Sorting sorting);
    }
}
