using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Domain.Entities
{
    public class ExtraType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(0, 100000000)]
        public decimal Price { get; set; }
    }
}
