using BookAndDrive.Application.DTOs.Order;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = _db.Orders
                .Include(o => o.User)
                .Select(o => new GetOrderInfoDTO
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    BookFrom = o.BookFrom,
                    BookTo = o.BookTo,
                    PlacedAt = o.PlacedAt,
                    TotalPrice = o.TotalPrice
                }).ToList();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id)
        {
            var order = _db.Orders
                .Include(o => o.User)
                .Select(o => new GetOrderInfoDTO
                {
                    Id = o.Id,
                    UserId = o.UserId,
                    FirstName = o.User.FirstName,
                    LastName = o.User.LastName,
                    BookFrom = o.BookFrom,
                    BookTo = o.BookTo,
                    PlacedAt = o.PlacedAt,
                    TotalPrice = o.TotalPrice
                }).FirstOrDefault(o => o.Id == id);

            return order == null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderDTO orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _db.Users.FirstOrDefault(u => u.Id == orderDto.UserId);

            if (user == null)
                return BadRequest("Invalid UserId");

            int rentalDays = orderDto.BookTo.DayNumber - orderDto.BookFrom.DayNumber;

            if (rentalDays < 1)
                return BadRequest("Rental period must be at least 1 day");

            if (rentalDays > 7)
                return BadRequest("Rental period cannot exceed 7 days");

            var order = new Order
            {
                UserId = orderDto.UserId,
                BookFrom = orderDto.BookFrom,
                BookTo = orderDto.BookTo,
                PlacedAt = DateTime.Now,
                TotalPrice = orderDto.TotalPrice
            };

            _db.Orders.Add(order);
            _db.SaveChanges();

            var response = new GetOrderInfoDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BookFrom = order.BookFrom,
                BookTo = order.BookTo,
                PlacedAt = order.PlacedAt,
                TotalPrice = order.TotalPrice
            };

            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] CreateOrderDTO orderDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _db.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            var user = _db.Users.FirstOrDefault(u => u.Id == orderDto.UserId);

            if (user == null)
                return BadRequest("Invalid UserId");

            int rentalDays = orderDto.BookTo.DayNumber - orderDto.BookFrom.DayNumber;

            if (rentalDays < 1)
                return BadRequest("Rental period must be at least 1 day");

            if (rentalDays > 7)
                return BadRequest("Rental period cannot exceed 7 days");

            order.UserId = orderDto.UserId;
            order.BookFrom = orderDto.BookFrom;
            order.BookTo = orderDto.BookTo;
            order.TotalPrice = orderDto.TotalPrice;

            _db.SaveChanges();

            var response = new GetOrderInfoDTO
            {
                Id = order.Id,
                UserId = order.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                BookFrom = order.BookFrom,
                BookTo = order.BookTo,
                PlacedAt = order.PlacedAt,
                TotalPrice = order.TotalPrice
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            var order = _db.Orders.FirstOrDefault(o => o.Id == id);

            if (order == null)
                return NotFound();

            _db.Orders.Remove(order);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
