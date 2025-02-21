using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs
{
    public class CreateCarDTO
    {
        [Required]
        public int CarTypeId { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public string Transmission { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string VIN { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int CarStatusId { get; set; }
    }
}
