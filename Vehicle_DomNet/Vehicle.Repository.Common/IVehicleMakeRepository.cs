using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IVehicleMakeModel> GetVehicleMakeById(int id);
        Task<IEnumerable<IVehicleMakeModel>> GetVehicleMakes();
        Task AddVehicleMake(IVehicleMakeModel vehicleMake);
        Task EditVehicleMake(int id, IVehicleMakeModel vehicleMake);
        Task DeleteVehicleMake(int id);
        Task<IEnumerable<IVehicleMakeModel>> GetFilteredVehicleMakes(string filter, Paging paging, Sorting sorting);
    }
}
