using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchProject.DTOs.DTOs;
using CleanArchProject.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.Api.Controllers {

    [ApiController]
    [Route("api/plants")]
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _plantService;

        public PlantController(IPlantService plantService)
        {
            _plantService = plantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<PlantDto> plants = await _plantService.GetAll();
            return Ok(plants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            PlantDto? plant = await _plantService.GetOne(id);
            return plant != null ? Ok(plant) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Register(PlantDto plant)
        {
            try
            {
                plant = await _plantService.Register(plant);
                return Ok(plant);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PlantDto plant)
        {
            if (id != plant.Id) return BadRequest();
            await _plantService.Update(plant);
            return NoContent();
        }
    }

}