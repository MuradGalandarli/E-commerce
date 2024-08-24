using Business.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Commerce;
using static Business.Commerce.ConcretCostumer.PaymentManager;

namespace Api.E_Commerce.Controllers.Costumer
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("create-payment-intent")]
        public async Task<IActionResult> CreatePaymentIntent([FromQuery] CreatePaymentIntentRequest paymentIntentRequest)
        {
            var paymentIntent = await _paymentService.CreatePayment(paymentIntentRequest);
            return Ok(paymentIntent);
        }

        [HttpPost("create-charge")]
        public async Task<IActionResult> CreateCharge([FromQuery] string source, [FromQuery] decimal amount, [FromQuery] string currency)
        {
            var charge = await _paymentService.ChargeCustomer(source, amount, currency);
            return Ok(charge);
        }

        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomer([FromQuery] string email, [FromQuery] string description)
        {
            var customer = await _paymentService.RegisterCustomer(email, description);
            return Ok(customer);
        }

        [HttpPost("confirm-payment")]
        public async Task<IActionResult> ConfirmPayment([FromQuery] string paymentIntentId)
        {
            var paymentIntent = await _paymentService.ConfirmPayment(paymentIntentId);
            return Ok(paymentIntent);
        }

        [HttpPost("Add-Id-Of-Payment")]
        public async Task<IActionResult> AddIdOfPayment([FromBody] Payment payment)
        {
            await _paymentService.AddIdOfPayment(payment);
            return Ok(payment.UserID);
        }
        [HttpGet("Get-By-Id-Payment")]
        public async Task<IActionResult> GetByIdPayment(int UserId)
        {
            var result = await _paymentService.GetByIdPayment(UserId);
            return Ok(result);
        }
        [HttpPut("Update-Payment-Id")]
        public async Task<IActionResult> UpdatePaymentId(Payment payment)
        {
            var result = await _paymentService.PaymentUpdate(payment);
            return Ok(result);
        }
        [HttpPost("RefundPayment")]
        public async Task<IActionResult> RefundPaymentAsync(int userId, int goodsId)
         {
            var result = await _paymentService.RefundPaymentAsync(userId, goodsId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

         }

    }
}

