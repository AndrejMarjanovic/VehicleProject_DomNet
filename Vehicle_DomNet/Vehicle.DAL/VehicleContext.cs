using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Model;

namespace Vehicle.DAL
{
    public partial class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        public VehicleContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         

        }

        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }
    }
}
