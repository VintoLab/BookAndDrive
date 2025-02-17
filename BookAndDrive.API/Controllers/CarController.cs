using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAndDrive.Infrastructure.Data;
using BookAndDrive.Application.DTOs;
using BookAndDrive.Domain.Entities;


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
                    CarTypeId = c.CarTypeId,
                    CarTypeName = c.CarType.Name,
                    Seats = c.Seats,
                    Transmission = c.Transmission,
                    Brand = c.Brand,
                    Year = c.Year,
                    VIN = c.VIN,
                    Price = c.Price,
                    CarStatusId = c.CarStatusId,
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
                    CarTypeId = c.CarTypeId,
                    CarTypeName = c.CarType.Name,
                    Seats = c.Seats,
                    Transmission = c.Transmission,
                    Brand = c.Brand,
                    Year = c.Year,
                    VIN = c.VIN,
                    Price = c.Price,
                    CarStatusId = c.CarStatusId,
                    CarStatusName = c.CarStatus.Name
                }).FirstOrDefault(c => c.Id == id);

            return car == null ? NotFound() : Ok(car);
        }
    }
}
