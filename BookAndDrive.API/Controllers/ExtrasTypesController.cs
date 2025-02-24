using BookAndDrive.Application.DTOs.Order;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtrasTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ExtrasTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetExtraTypes()
        {
            var extraTypes = _db.ExtraTypes;
            return Ok(extraTypes);
        }

        [HttpGet("{id}")]
        public IActionResult GetExtraType(int id)
        {
            var extraType = _db.ExtraTypes.FirstOrDefault(et => et.Id == id);
            return extraType == null ? NotFound() : Ok(extraType);
        }

        [HttpPost]
        public IActionResult CreateExtraType([FromBody] CreateExtraTypeDTO extraTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (_db.ExtraTypes.Any(et => et.Name == extraTypeDto.Name))
                return BadRequest("Extra type with this name already exists");

            var extraType = new ExtraType
            {
                Name = extraTypeDto.Name,
                Price = extraTypeDto.Price
            };

            _db.ExtraTypes.Add(extraType);
            _db.SaveChanges();

            var response = new GetExtraTypeDTO
            {
                Id = extraType.Id,
                Name = extraType.Name,
                Price = extraType.Price
            };

            return CreatedAtAction(nameof(GetExtraType), new { id = extraType.Id }, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExtraType(int id, [FromBody] CreateExtraTypeDTO extraTypeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var extraType = _db.ExtraTypes.FirstOrDefault(et => et.Id == id);
            if (extraType == null)
                return NotFound();

            if (_db.ExtraTypes.Any(et => et.Name == extraTypeDto.Name && et.Id != id))
                return BadRequest("Extra type with this name already exists");

            extraType.Name = extraTypeDto.Name;
            extraType.Price = extraTypeDto.Price;

            _db.SaveChanges();

            var response = new GetExtraTypeDTO
            {
                Id = extraType.Id,
                Name = extraType.Name,
                Price = extraType.Price
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteExtraType(int id)
        {
            var extraType = _db.ExtraTypes.FirstOrDefault(et => et.Id == id);
            if (extraType == null)
                return NotFound();

            _db.ExtraTypes.Remove(extraType);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
