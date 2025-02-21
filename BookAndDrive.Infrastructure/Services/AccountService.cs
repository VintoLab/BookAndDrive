using BookAndDrive.Application.DTOs.Account;
using BookAndDrive.Application.Interfaces;
using BookAndDrive.Domain.Entities;
using BookAndDrive.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookAndDrive.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _config;

        public AccountService(ApplicationDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<bool> RegisterUserAsync(RegisterUserDTO userDTO)
        {
            if (await _db.Users.AnyAsync(u => u.Email == userDTO.Email))
                return false;

            var user = new User
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = HashPassword(userDTO.Password),
                PhoneNumber = userDTO.PhoneNumber
            };

            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<string> LoginUserAsync(LoginUserDTO userDTO)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == userDTO.Email);

            if (user == null || user.Password != HashPassword(userDTO.Password))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),

                Expires = DateTime.UtcNow.AddMinutes(double.Parse(_config["JwtSettings:ExpireMinutes"])),
                Issuer = _config["JwtSettings:Issuer"],
                Audience = _config["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }
    }
}
