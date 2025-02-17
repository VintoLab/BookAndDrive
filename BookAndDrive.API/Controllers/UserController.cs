using BookAndDrive.Application.DTOs;
using BookAndDrive.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _db.Users;
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            return user == null ? NotFound() : Ok(user);
        }

        //[Authorize]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserInfoDTO userDTO)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound("User not found");

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.Email = userDTO.Email;
            user.PhoneNumber = userDTO.PhoneNumber;

            if (!string.IsNullOrEmpty(userDTO.Password))
            {
                user.Password = HashPassword(userDTO.Password);
            }

            _db.Users.Update(user);
            _db.SaveChanges();

            return Ok("User data updated successfully.");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound("User not found");

            _db.Users.Remove(user);
            _db.SaveChanges();

            return NoContent();
        }

        //[Authorize(Roles = "User")]
        [HttpPost("{id}/upload-licence")]
        public IActionResult UploadDriverLicence(int id, [FromBody] UserDriverLicenceDTO licenceDTO)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound("User not Found.");

            user.DriverLicenceFirst = licenceDTO.DriverLicenceFirst;
            user.DriverLicenceSecond = licenceDTO.DriverLicenceSecond;
            user.IsDriverLicenceVerified = false;

            _db.Users.Update(user);
            _db.SaveChanges();

            return Ok("The driver's licence has been uploaded. The check is pending.");
        }



        #region HashPassword

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }


        #endregion
    }
}
