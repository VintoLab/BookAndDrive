using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class GetOrderCarDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarTypeName { get; set; }
        public decimal Price { get; set; }
    }
}
