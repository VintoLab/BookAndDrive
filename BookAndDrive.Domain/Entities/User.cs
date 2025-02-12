using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Role { get; set; } = "User";
        public byte[]? DriverLicenceFirst { get; set; }
        public byte[]? DriverLicenceSecond { get; set; }
        public bool? IsDriverLicenceVerified { get; set; }

        [ValidateNever]
        public IEnumerable<Address> UserAddresses { get; set; }

    }
}
