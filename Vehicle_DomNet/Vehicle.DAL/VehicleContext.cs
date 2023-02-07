using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.DAL.Entiteti;
using Microsoft.EntityFrameworkCore;

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VehicleModel>()
                 .HasOne(pt => pt.VehicleMake).WithMany().HasForeignKey(pt => pt.VehicleMakeId)
                 .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }

    }
}
