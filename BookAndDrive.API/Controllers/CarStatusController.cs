using BookAndDrive.Application.DTOs.Car;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStatusController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarStatusController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetCarStatuses()
        {
            var carStatuses = _db.CarStatuses;
            return Ok(carStatuses);
        }

        [HttpGet("{id}")]
        public IActionResult GetCarStatus(int id)
        {
            var carStatus = _db.CarStatuses.FirstOrDefault(u => u.Id == id);

            return carStatus == null ? NotFound() : Ok(carStatus);
        }

        [HttpPost]
        public IActionResult CreateCarStatus([FromBody] CarStatusesDTO carStatusDTO)
        {
            if (carStatusDTO == null || string.IsNullOrEmpty(carStatusDTO.Name))
                return BadRequest("Invalid data");

            var newCarStatus = new CarStatus
            {
                Name = carStatusDTO.Name
            };

            _db.CarStatuses.Add(newCarStatus);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetCarStatus), new { id = newCarStatus.Id }, carStatusDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCarStatus(int id, [FromBody] CarStatusesDTO carStatusDTO)
        {
            if (carStatusDTO == null || string.IsNullOrEmpty(carStatusDTO.Name))
                return BadRequest("Invalid data");

            var carStatus = _db.CarStatuses.FirstOrDefault(ct => ct.Id == id);

            if (carStatus == null)
                return NotFound("Car Status not found");

            carStatus.Name = carStatusDTO.Name;

            _db.CarStatuses.Update(carStatus);
            _db.SaveChanges();

            return Ok("Car Status updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCarStatus(int id)
        {
            var carStatus = _db.CarStatuses.FirstOrDefault(ct => ct.Id == id);

            if (carStatus == null)
                return NotFound("Car Status not found");

            _db.CarStatuses.Remove(carStatus);
            _db.SaveChanges();

            return NoContent();
        }

    }
}
