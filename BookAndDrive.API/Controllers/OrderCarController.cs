using BookAndDrive.Application.DTOs.Order;
using BookAndDrive.Application.Interfaces;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCarController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public OrderCarController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetOrderCars()
        {
            var orderCars = _db.OrderCars
                .Include(oc => oc.Car)
                .ThenInclude(c => c.CarType)
                .Select(oc => new GetOrderCarDTO
                {
                    Id = oc.Id,
                    OrderId = oc.OrderId,
                    CarId = oc.CarId,
                    CarBrand = oc.Car.Brand,
                    CarTypeName = oc.Car.CarType.Name,
                    Price = oc.Price
                }).ToList();

            return Ok(orderCars);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderCar(int id)
        {
            var orderCar = _db.OrderCars
                .Include(oc => oc.Car)
                .ThenInclude(c => c.CarType)
                .Select(oc => new GetOrderCarDTO
                {
                    Id = oc.Id,
                    OrderId = oc.OrderId,
                    CarId = oc.CarId,
                    CarBrand = oc.Car.Brand,
                    CarTypeName = oc.Car.CarType.Name,
                    Price = oc.Price
                }).FirstOrDefault(oc => oc.Id == id);

            return orderCar == null ? NotFound() : Ok(orderCar);
        }

        [HttpPost]
        public IActionResult CreateOrderCar([FromBody] CreateOrderCarDTO orderCarDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _db.Orders.FirstOrDefault(o => o.Id == orderCarDto.OrderId);
            if (order == null)
                return BadRequest("Invalid OrderId");

            var car = _db.Cars.FirstOrDefault(c => c.Id == orderCarDto.CarId);
            if (car == null)
                return BadRequest("Invalid CarId");

            var orderCar = new OrderCar
            {
                OrderId = orderCarDto.OrderId,
                CarId = orderCarDto.CarId,
                Price = orderCarDto.Price
            };

            _db.OrderCars.Add(orderCar);
            _db.SaveChanges();

            var response = new GetOrderCarDTO
            {
                Id = orderCar.Id,
                OrderId = orderCar.OrderId,
                CarId = orderCar.CarId,
                CarBrand = car.Brand,
                CarTypeName = car.CarType.Name,
                Price = orderCar.Price
            };

            return CreatedAtAction(nameof(GetOrderCar), new { id = orderCar.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderCar(int id, [FromBody] CreateOrderCarDTO orderCarDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderCar = _db.OrderCars.FirstOrDefault(oc => oc.Id == id);
            if (orderCar == null)
                return NotFound();

            var order = _db.Orders.FirstOrDefault(o => o.Id == orderCarDto.OrderId);
            if (order == null)
                return BadRequest("Invalid OrderId");

            var car = _db.Cars.FirstOrDefault(c => c.Id == orderCarDto.CarId);
            if (car == null)
                return BadRequest("Invalid CarId");

            orderCar.OrderId = orderCarDto.OrderId;
            orderCar.CarId = orderCarDto.CarId;
            orderCar.Price = orderCarDto.Price;

            _db.SaveChanges();

            var response = new GetOrderCarDTO
            {
                Id = orderCar.Id,
                OrderId = orderCar.OrderId,
                CarId = orderCar.CarId,
                CarBrand = car.Brand,
                CarTypeName = car.CarType.Name,
                Price = orderCar.Price
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderCar(int id)
        {
            var orderCar = _db.OrderCars.FirstOrDefault(oc => oc.Id == id);
            if (orderCar == null)
                return NotFound();

            _db.OrderCars.Remove(orderCar);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
