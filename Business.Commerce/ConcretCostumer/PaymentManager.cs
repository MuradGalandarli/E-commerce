using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Shared.Commerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class PaymentManager
    {
        public class PaymentService: IPaymentService
        {
            private readonly IStripeRepository _stripeRepository;

            public PaymentService(IStripeRepository stripeRepository)
            {
                _stripeRepository = stripeRepository;
            }

            public async Task<PaymentIntent> CreatePayment(CreatePaymentIntentRequest paymentIntentRequest)
            {
                return await _stripeRepository.CreatePaymentIntentAsync(paymentIntentRequest);
            }

            public async Task<Charge> ChargeCustomer(string source, decimal amount, string currency)
            {
                return await _stripeRepository.CreateChargeAsync(source, amount, currency);
            }

            public async Task<Customer> RegisterCustomer(string email, string description)
            {
                return await _stripeRepository.CreateCustomerAsync(email, description);
            }

            public async Task<PaymentIntent> ConfirmPayment(string paymentIntentId)
            {
                return await _stripeRepository.ConfirmPaymentIntentAsync(paymentIntentId);
            }

            public async Task<Payment> AddIdOfPayment(Payment payment)
            {
               await _stripeRepository.AddIdOfPayment(payment);
                return payment;
            }

            public async Task<Payment> GetByIdPayment(int UserId)
            {
               var result = await _stripeRepository.GetByIdPayment(UserId);
                return result;
            }

            public async Task<Payment> PaymentUpdate(Payment payment)
            {
               await _stripeRepository.PaymentIdUpdate(payment);
                return payment;
            }

            public async Task<Refund> RefundPaymentAsync(int userId, int goodsId)
            {
               var result = await _stripeRepository.RefundPaymentAsync(userId, goodsId);
                     return result;            
            }
        }

    }
}
