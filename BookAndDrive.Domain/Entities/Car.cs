using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Domain.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CarType")]
        public int CarTypeId { get; set; }
        [ValidateNever]
        public CarType CarType { get; set; }

        [Range(1, 12)]
        public int Seats { get; set; }
        public string Transmission { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        [Required]
        [MaxLength(17)]
        public string VIN { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("CarStatus")]
        public int CarStatusId { get; set; }
        [ValidateNever]
        public CarStatus CarStatus { get; set; }

    }
}
