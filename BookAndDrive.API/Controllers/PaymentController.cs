using BookAndDrive.Infrastructure.Services;
using BookAndDrive.Application.DTOs.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAndDrive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly PaymentService _paymentService;
        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-payment-intent")]
        public IActionResult CreatePaymentIntent([FromBody] PaymentRequestDTO paymentRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid payment data.");

            var clientSecret = _paymentService.CreatePaymentIntent(paymentRequest.Amount, paymentRequest.Currency);
            return Ok(new { clientSecret });
        }
    }
}
