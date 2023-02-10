﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        public async Task<ActionResult<VehicleMakeGetModel>> GetVehicleMakeById(int id)
        {
            try
            {
                IVehicleMakeModel vehicleMake = await _service.GetVehicleMakeById(id);
                VehicleMakeGetModel vehicleMakeGetModel = _mapper.Map<VehicleMakeGetModel>(vehicleMake);
                return vehicleMakeGetModel == null ? NotFound() : Ok(vehicleMakeGetModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicleMakes()
        {
            IEnumerable<IVehicleMakeModel> vehicleMakes = await _service.GetVehicleMakes();
            List<VehicleMakeGetModel> vehicleMakesGetModel = _mapper.Map<List<VehicleMakeGetModel>>(vehicleMakes);
            return Ok(vehicleMakesGetModel);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleMakePostModel>> PostVehicleMake(VehicleMakePostModel vehicleMakePostModel)
        {
            try
            {
                IVehicleMakeModel vehicleMakeModel = _mapper.Map<VehicleMakeModel>(vehicleMakePostModel);
                await _service.AddVehicleMake(vehicleMakeModel);
                return Ok(vehicleMakePostModel);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleMakePostModel>> PutVehicleMake(int id, VehicleMakePostModel vehicleMakePostModel)
        {
            try
            {
                IVehicleMakeModel vehicleMake = _mapper.Map<VehicleMakeModel>(vehicleMakePostModel);
                await _service.EditVehicleMake(id, vehicleMake);
                return Ok(vehicleMakePostModel);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
