﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.DAL.Entiteti
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Abrv { get; set; } = null!;
    }
}
