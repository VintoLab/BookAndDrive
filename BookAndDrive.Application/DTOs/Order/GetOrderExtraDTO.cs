using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class GetOrderExtraDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ExtraTypeId { get; set; }
        public string ExtraTypeName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
