using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Order
{
    public class GetOrderInfoDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BookFrom { get; set; }
        public DateOnly BookTo { get; set; }
        public DateTime PlacedAt { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
