using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;
using Vehicle.Model.Common;

namespace Vehicle.Repository.Common
{
    public interface IVehicleMakeRepository
    {
        Task<IVehicleMake> GetVehicleMakeById(int id);

    }
}
