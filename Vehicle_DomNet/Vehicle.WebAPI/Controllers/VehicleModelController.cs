using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vehicle.Common;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Service.Common;
using Vehicle.WebAPI.Models;

namespace Vehicle.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleModelController : ControllerBase
    {
        private readonly IVehicleModelService _service;
        private IMapper _mapper;
        public VehicleModelController(IVehicleModelService service, IMapper map)
        {
            _service = service;
            _mapper = map;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModelGetModel>> GetVehicleMakeById(int id)
        {
            try
            {
                IVehicleModelModel vehicleModel = await _service.GetVehicleModelById(id);
                VehicleModelGetModel vehicleModelGetModel = _mapper.Map<VehicleModelGetModel>(vehicleModel);
                return vehicleModelGetModel == null ? NotFound() : Ok(vehicleModelGetModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleModels()
        {
            IEnumerable<IVehicleModelModel> vehicleModels = await _service.GetVehicleModels();
            List<VehicleModelGetModel> vehicleModelsGetModel = _mapper.Map<List<VehicleModelGetModel>>(vehicleModels);
            return Ok(vehicleModelsGetModel);
        }

        [HttpGet("Filtered")]
        public async Task<IActionResult> GetFilteredVehicleModels(string? search, int? page, string? sortBy, bool isDesc)
        {
            Sorting sorting = new Sorting(sortBy, isDesc);
            Paging paging = new Paging(page);
            IEnumerable<IVehicleModelModel> vehicleModels = await _service.GetFilteredVehicleModels(search, paging, sorting);
            List<VehicleModelGetModel> vehicleModelGetModel = _mapper.Map<List<VehicleModelGetModel>>(vehicleModels);
            return Ok(vehicleModelGetModel);

        }

        [HttpPost]
        public async Task<ActionResult<VehicleModelPostModel>> PostVehicleModel(VehicleModelPostModel vehicleModelPostModel)
        {
            try
            {
                IVehicleModelModel vehicleModelModel = _mapper.Map<VehicleModelModel>(vehicleModelPostModel);
                await _service.AddVehicleModel(vehicleModelModel);
                return Ok(vehicleModelPostModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModelPostModel>> PutVehicleModel(int id, VehicleModelPostModel vehicleModelPostModel)
        {
            try
            {
                IVehicleModelModel vehicleModel = _mapper.Map<VehicleModelModel>(vehicleModelPostModel);
                await _service.EditVehicleModel(id, vehicleModel);
                return Ok(vehicleModelPostModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicleModel(int id)
        {
           // IVehicleModelModel vehicleModel = await _service.GetVehicleModelById(id);
            try
            {
                await _service.DeleteVehicleModel(id);
                // return Ok(vehicleModel);
                return NoContent();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}

