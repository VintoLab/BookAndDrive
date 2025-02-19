using BookAndDrive.Application.DTOs;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarTypeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetCarTypes()
        {
            var carTypes = _db.CarTypes;
            return Ok(carTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarType(int id)
        {
            var carType = _db.CarTypes.FirstOrDefault(u => u.Id == id);

            return carType == null ? NotFound() : Ok(carType);
        }

        [HttpPost]
        public IActionResult CreateCarType([FromBody] CarTypesDTO carTypeDTO)
        {
            if (carTypeDTO == null || string.IsNullOrEmpty(carTypeDTO.Name))
                return BadRequest("Invalid data");

            var newCarType = new CarType
            {
                Name = carTypeDTO.Name
            };

            _db.CarTypes.Add(newCarType);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetCarType), new { id = newCarType.Id }, carTypeDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarType(int id, [FromBody] CarTypesDTO carTypeDTO)
        {
            if (carTypeDTO == null || string.IsNullOrEmpty(carTypeDTO.Name))
                return BadRequest("Invalid data");

            var carType = _db.CarTypes.FirstOrDefault(ct => ct.Id == id);

            if (carType == null)
                return NotFound("Car type not found");

            carType.Name = carTypeDTO.Name;

            _db.CarTypes.Update(carType);
            _db.SaveChanges();

            return Ok("Car type updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarType(int id)
        {
            var carType = _db.CarTypes.FirstOrDefault(ct => ct.Id == id);

            if (carType == null)
                return NotFound("Car type not found");

            _db.CarTypes.Remove(carType);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
