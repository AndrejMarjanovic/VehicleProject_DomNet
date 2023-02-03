﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Entiteti
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int VehicleMakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
