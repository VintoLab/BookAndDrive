using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs
{
    public class UserDriverLicenceDTO
    {
        [Required]
        public byte[]? DriverLicenceFirst { get; set; }
        [Required]
        public byte[]? DriverLicenceSecond { get; set; }
    }
}
