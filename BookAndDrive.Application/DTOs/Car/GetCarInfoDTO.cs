using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Car
{
    public class GetCarInfoDTO
    {
        public int Id { get; set; }
        public string CarTypeName { get; set; }

        public int Seats { get; set; }
        public string Transmission { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public string VIN { get; set; }
        public decimal Price { get; set; }

        public string CarStatusName { get; set; }
    }
}
