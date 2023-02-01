using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model.Common;

namespace Vehicle.Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abrv { get; set; } = null!;
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; } = null!;
    }
}
