using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Car
{
    public class CreateCarDTO
    {
        [Required]
        public int CarTypeId { get; set; }
        [Required]
        //[MinLength(0)]
        public int Seats { get; set; }
        [Required]
        public string Transmission { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CarStatusId { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
