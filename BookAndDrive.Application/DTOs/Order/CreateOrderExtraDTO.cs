using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class CreateOrderExtraDTO
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ExtraTypeId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
