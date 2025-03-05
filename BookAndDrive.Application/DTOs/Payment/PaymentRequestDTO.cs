using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndDrive.Application.DTOs.Payment
{
    public class PaymentRequestDTO
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "usd";
    }
}
