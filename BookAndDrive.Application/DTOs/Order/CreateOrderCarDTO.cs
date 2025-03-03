using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class CreateOrderCarDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int CarId { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
