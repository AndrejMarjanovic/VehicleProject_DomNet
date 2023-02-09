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
        public async Task<VehicleMakeRestModel> GetVehicleMakeById(int id)
        {
            IVehicleMakeModel vehicleMake = await _service.GetVehicleMakeById(id);
            VehicleMakeRestModel vehicleMakeRestModel = _mapper.Map<VehicleMakeRestModel>(vehicleMake);
            return vehicleMakeRestModel;
        }

        [HttpGet]
        public async Task<List<VehicleMakeRestModel>> GetVehicleMakes()
        {
            IEnumerable<IVehicleMakeModel> vehicleMakes = await _service.GetVehicleMakes();
            List<VehicleMakeRestModel> vehicleMakesRestModel = _mapper.Map<List<VehicleMakeRestModel>>(vehicleMakes);
            return vehicleMakesRestModel;
        }

        [HttpPost]
        public async Task AddVehicleMake(VehicleMakeRestModel vehicleMakeRestModel)
        {
            try
            {
                IVehicleMakeModel vehicleMakeModel = _mapper.Map<VehicleMakeModel>(vehicleMakeRestModel);
                await _service.AddVehicleMake(vehicleMakeModel);
            }
            catch(Exception ex)
            {
                throw new Exception("Post request failed.", ex);
            }
        }

    }
}
