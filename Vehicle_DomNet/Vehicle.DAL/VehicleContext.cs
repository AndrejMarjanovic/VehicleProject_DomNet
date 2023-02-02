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

            SeedVehicleMake(modelBuilder);
            SeedVehicleModel(modelBuilder);
        }

        public DbSet<VehicleMake> VehicleMake { get; set; }
        public DbSet<VehicleModel> VehicleModel { get; set; }

        private void SeedVehicleMake(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { Id = 1, Name = "Volkswagen", Abrv = "VW" }
                );
        }

        private void SeedVehicleModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { Id = 1, Name = "Golf", Abrv = "G", VehicleMakeId = 1 }
                );
        }
    }
}
