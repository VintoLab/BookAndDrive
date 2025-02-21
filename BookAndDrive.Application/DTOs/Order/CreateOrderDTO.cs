using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class CreateOrderDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateOnly BookFrom { get; set; }
        [Required]
        public DateOnly BookTo { get; set; }
        [Required]
        public decimal TotalPrice { get; set; }
    }
}
