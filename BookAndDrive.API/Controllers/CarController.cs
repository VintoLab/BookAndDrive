using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAndDrive.Infrastructure.Data;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Application.DTOs.Car;


namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CarController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = _db.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarStatus)
                .Select(c => new GetCarInfoDTO
                {
                    Id = c.Id,
                    CarTypeName = c.CarType.Name,
                    Seats = c.Seats,
                    Transmission = c.Transmission,
                    Brand = c.Brand,
                    Year = c.Year,
                    VIN = c.VIN,
                    Price = c.Price,
                    CarStatusName = c.CarStatus.Name
                }).ToList();

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(int id)
        {
            var car = _db.Cars
                .Include(c => c.CarType)
                .Include(c => c.CarStatus)
                .Select(c => new GetCarInfoDTO
                {
                    Id = c.Id,
                    CarTypeName = c.CarType.Name,
                    Seats = c.Seats,
                    Transmission = c.Transmission,
                    Brand = c.Brand,
                    Year = c.Year,
                    VIN = c.VIN,
                    Price = c.Price,
                    CarStatusName = c.CarStatus.Name
                }).FirstOrDefault(c => c.Id == id);

            return car == null ? NotFound() : Ok(car);
        }

        [HttpPost]
        public IActionResult CreateCar([FromBody] CreateCarDTO carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carType = _db.CarTypes.FirstOrDefault(ct => ct.Id == carDto.CarTypeId);
            var carStatus = _db.CarStatuses.FirstOrDefault(cs => cs.Id == carDto.CarStatusId);

            if (carType == null || carStatus == null)
                return BadRequest("Invalid CarTypeId or CarStatusId");

            if (_db.Cars.Any(c => c.VIN == carDto.VIN))
                return BadRequest("Car with this VIN already exists");

            var car = new Car
            {
                CarTypeId = carDto.CarTypeId,
                Seats = carDto.Seats,
                Transmission = carDto.Transmission,
                Brand = carDto.Brand,
                Year = carDto.Year,
                VIN = carDto.VIN,
                Price = carDto.Price,
                CarStatusId = carDto.CarStatusId
            };

            _db.Cars.Add(car);
            _db.SaveChanges();

            var response = new GetCarInfoDTO
            {
                Id = car.Id,
                CarTypeName = carType.Name,
                Seats = car.Seats,
                Transmission = car.Transmission,
                Brand = car.Brand,
                Year = car.Year,
                VIN = car.VIN,
                Price = car.Price,
                CarStatusName = carStatus.Name
            };

            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCar(int id, [FromBody] CreateCarDTO carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var car = _db.Cars.FirstOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();

            var carType = _db.CarTypes.FirstOrDefault(ct => ct.Id == carDto.CarTypeId);
            var carStatus = _db.CarStatuses.FirstOrDefault(cs => cs.Id == carDto.CarStatusId);

            if (carType == null || carStatus == null)
                return BadRequest("Invalid CarTypeId or CarStatusId");

            if (_db.Cars.Any(c => c.VIN == carDto.VIN && c.Id != id))
                return BadRequest("Another car with this VIN already exists");

            car.CarTypeId = carDto.CarTypeId;
            car.Seats = carDto.Seats;
            car.Transmission = carDto.Transmission;
            car.Brand = carDto.Brand;
            car.Year = carDto.Year;
            car.VIN = carDto.VIN;
            car.Price = carDto.Price;
            car.CarStatusId = carDto.CarStatusId;

            _db.SaveChanges();

            var response = new GetCarInfoDTO
            {
                Id = car.Id,
                CarTypeName = carType.Name,
                Seats = car.Seats,
                Transmission = car.Transmission,
                Brand = car.Brand,
                Year = car.Year,
                VIN = car.VIN,
                Price = car.Price,
                CarStatusName = carStatus.Name
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _db.Cars.FirstOrDefault(c => c.Id == id);

            if (car == null)
                return NotFound();

            _db.Cars.Remove(car);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
