using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(25)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
