namespace Vehicle.WebAPI.Models
{
    public class VehicleModelGetModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMakeGetModel VehicleMake { get; set; }
    }
}
