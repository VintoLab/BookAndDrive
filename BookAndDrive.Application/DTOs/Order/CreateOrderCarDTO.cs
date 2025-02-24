using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class CreateOrderCarDTO
    {
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }
    }
}
