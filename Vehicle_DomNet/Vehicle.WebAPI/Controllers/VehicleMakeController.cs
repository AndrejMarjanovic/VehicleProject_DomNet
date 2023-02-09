using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleMakeController : ControllerBase
    {
        private readonly IVehicleMakeService _service;
        private IMapper _mapper;
        public VehicleMakeController(IVehicleMakeService service, IMapper map)
        {
            _service = service;
            _mapper = map;
        }

        [HttpGet("{id}")]
        public async Task<VehicleMakeModel> GetVehicleMakeById(int id)
        {
            IVehicleMake vehicleMake = await _service.GetVehicleMakeById(id);
            VehicleMakeModel VM = _mapper.Map<VehicleMakeModel>(vehicleMake);
            return VM;
        }

    }
}
