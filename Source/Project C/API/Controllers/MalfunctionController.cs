﻿using Data.Exceptions;
using Data.Interfaces;
using Data.Models;

using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MalfunctionController : ControllerBase
    {
        private readonly IMalfunctionRepository _malfunctionRepository;

        public MalfunctionController(IMalfunctionRepository malfunctionRepository)
        {
            _malfunctionRepository = malfunctionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var malfunctions = await _malfunctionRepository.GetAll();
            if (malfunctions.Count == 0)
                return NoContent();

            return Ok(malfunctions);
        }

        [HttpGet("{malfunctionId}")]
        public async Task<IActionResult> GetById(int malfunctionId)
        {
            try
            {
                var malfunction = await _malfunctionRepository.GetById(malfunctionId);
                return Ok(malfunction);
            }
            catch (ModelNotFoundException)
            {
                return BadRequest($"A malfunction with ID {malfunctionId} was not found");
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest("Invalid ID provided");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Malfunction malfunction)
        {
            if (malfunction is null)
                return BadRequest("Invalid body content provided");

            var model = await _malfunctionRepository.Create(malfunction);
            return Created($"Malfunction/{model.Id}", model);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Malfunction malfunction)
        {
            if (malfunction is null)
                return BadRequest("Invalid body content provided");

            try
            {
                return Ok(await _malfunctionRepository.Update(malfunction));
            }
            catch (ModelNotFoundException)
            {
                return BadRequest($"A malfunction with ID {malfunction.Id} was not found.");
            }
        }

        [HttpPost("{malfunctionId}")]
        public async Task<IActionResult> Delete(int malfunctionId)
        {
            if (malfunctionId <= 0)
                return BadRequest("Invalid ID provided");

            try
            {
                await _malfunctionRepository.Delete(malfunctionId);
                return Ok();
            }
            catch (ModelNotFoundException)
            {
                return BadRequest($"A malfunction with ID {malfunctionId} was not found");
            }
        }
    }
}
