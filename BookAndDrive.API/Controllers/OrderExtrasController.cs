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
    public class OrderExtrasController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public OrderExtrasController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetOrderExtras()
        {
            var orderExtras = _db.OrderExtras
                .Include(oe => oe.ExtraType)
                .Select(oe => new GetOrderExtraDTO
                {
                    Id = oe.Id,
                    OrderId = oe.OrderId,
                    ExtraTypeId = oe.ExtraTypeId,
                    ExtraTypeName = oe.ExtraType.Name,
                    Price = oe.Price,
                    Quantity = oe.Quantity
                }).ToList();

            return Ok(orderExtras);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderExtra(int id)
        {
            var orderExtra = _db.OrderExtras
                .Include(oe => oe.ExtraType)
                .Select(oe => new GetOrderExtraDTO
                {
                    Id = oe.Id,
                    OrderId = oe.OrderId,
                    ExtraTypeId = oe.ExtraTypeId,
                    ExtraTypeName = oe.ExtraType.Name,
                    Price = oe.Price,
                    Quantity = oe.Quantity
                }).FirstOrDefault(oe => oe.Id == id);

            return orderExtra == null ? NotFound() : Ok(orderExtra);
        }

        [HttpPost]
        public IActionResult CreateOrderExtra([FromBody] CreateOrderExtraDTO orderExtraDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var order = _db.Orders.FirstOrDefault(o => o.Id == orderExtraDto.OrderId);
            if (order == null)
                return BadRequest("Invalid OrderId");

            var extraType = _db.ExtraTypes.FirstOrDefault(et => et.Id == orderExtraDto.ExtraTypeId);
            if (extraType == null)
                return BadRequest("Invalid ExtraTypeId");

            var orderExtra = new OrderExtras
            {
                OrderId = orderExtraDto.OrderId,
                ExtraTypeId = orderExtraDto.ExtraTypeId,
                Price = orderExtraDto.Price,
                Quantity = orderExtraDto.Quantity
            };

            _db.OrderExtras.Add(orderExtra);
            _db.SaveChanges();

            var response = new GetOrderExtraDTO
            {
                Id = orderExtra.Id,
                OrderId = orderExtra.OrderId,
                ExtraTypeId = orderExtra.ExtraTypeId,
                ExtraTypeName = extraType.Name,
                Price = orderExtra.Price,
                Quantity = orderExtra.Quantity
            };

            return CreatedAtAction(nameof(GetOrderExtra), new { id = orderExtra.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderExtra(int id, [FromBody] CreateOrderExtraDTO orderExtraDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderExtra = _db.OrderExtras.FirstOrDefault(oe => oe.Id == id);
            if (orderExtra == null)
                return NotFound();

            var order = _db.Orders.FirstOrDefault(o => o.Id == orderExtraDto.OrderId);
            if (order == null)
                return BadRequest("Invalid OrderId");

            var extraType = _db.ExtraTypes.FirstOrDefault(et => et.Id == orderExtraDto.ExtraTypeId);
            if (extraType == null)
                return BadRequest("Invalid ExtraTypeId");

            orderExtra.OrderId = orderExtraDto.OrderId;
            orderExtra.ExtraTypeId = orderExtraDto.ExtraTypeId;
            orderExtra.Price = orderExtraDto.Price;
            orderExtra.Quantity = orderExtraDto.Quantity;

            _db.SaveChanges();

            var response = new GetOrderExtraDTO
            {
                Id = orderExtra.Id,
                OrderId = orderExtra.OrderId,
                ExtraTypeId = orderExtra.ExtraTypeId,
                ExtraTypeName = extraType.Name,
                Price = orderExtra.Price,
                Quantity = orderExtra.Quantity
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrderExtra(int id)
        {
            var orderExtra = _db.OrderExtras.FirstOrDefault(oe => oe.Id == id);
            if (orderExtra == null)
                return NotFound();

            _db.OrderExtras.Remove(orderExtra);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
