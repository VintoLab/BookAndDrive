using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } = "User";
        public byte[]? DriverLicenceFirst { get; set; }
        public byte[]? DriverLicenceSecond { get; set; }
        public bool? IsDriverLicenceVerified { get; set; }

    }
}
