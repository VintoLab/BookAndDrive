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
    public class OrderExtras
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [ValidateNever]
        public Order Order { get; set; }

        [ForeignKey("ExtraType")]
        public int ExtraTypeId { get; set; }
        [ValidateNever]
        public ExtraType ExtraType { get; set; }
        [Range(0, 100000000)]
        public decimal Price { get; set; }
        [Range(0, 100)]
        public int Quantity { get; set; }
    }
}
