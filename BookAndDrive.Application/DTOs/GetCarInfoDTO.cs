using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs
{
    public class GetCarInfoDTO
    {
        public int Id { get; set; }
        public int CarTypeId { get; set; }
        public string CarTypeName { get; set; }

        public int Seats { get; set; }
        public string Transmission { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public decimal Price { get; set; }

        public int CarStatusId { get; set; }
        public string CarStatusName { get; set; }
    }
}
