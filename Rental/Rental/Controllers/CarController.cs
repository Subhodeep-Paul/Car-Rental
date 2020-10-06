using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rental.Data;
using Rental.DTO;
using Rental.Models;

namespace Rental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repo;
        private readonly IMapper _mapper;
        public CarController(ICarRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCar()
        {
            var result = await _repo.GetCar();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCar")]
        public async Task<IActionResult> GetCar(int id)
        {
            var result = await _repo.GetCar(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAvailability(int id)
        {
            var update= await _repo.UpdateAvailability(id);
            await _repo.SaveChangesAsync();
            return Ok(update);
            
        }


        [HttpPost("Add")]
        public async Task<IActionResult> PostCar(CarForAddDto carForAdd )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var car = _mapper.Map<Car>(carForAdd);

                    _repo.AddCar(car);
                    if (await _repo.SaveChangesAsync())
                    {
                        var newModel = _mapper.Map<CarForAddDto>(car);
                        var location = Url.Link("GetCar", new { id = car.A_ID });
                        return StatusCode(201);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return BadRequest();
        }
    }
}
