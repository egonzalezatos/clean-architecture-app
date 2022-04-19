using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchProject.DTOs.DTOs;
using CleanArchProject.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchProject.Api.Controllers
{

    [ApiController]
    [Route("api/subplants")]
    public class SubplantController : ControllerBase
    {
        private readonly ISubplantService _subplantService;

        public SubplantController(ISubplantService subplantService)
        {
            _subplantService = subplantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<SubplantDto> subplants = await _subplantService.GetAll();
            return Ok(subplants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            SubplantDto? subplant = await _subplantService.GetOne(id);
            return subplant != null ? Ok(subplant) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Register(SubplantDto subplant)
        {
            try
            {
                subplant = await _subplantService.Register(subplant);
                return Created($"{Request.Path.Value} {nameof(Register)}", subplant);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SubplantDto subplant)
        {
            if (id != subplant.Id) return BadRequest();
            await _subplantService.Update(subplant);
            return NoContent();
        }
    }
}