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
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [ValidateNever]
        public User User { get; set; }

        public DateOnly BookFrom { get; set; }
        public DateOnly BookTo { get; set; }
        public DateTime PlacedAt { get; set; }
        [Range(0, 100000000)]
        public decimal TotalPrice { get; set; }
    }
}
