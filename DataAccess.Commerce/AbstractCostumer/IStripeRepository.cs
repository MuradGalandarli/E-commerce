using EntityCommerce;
using Shared.Commerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
  
        public interface IStripeRepository
        {
        Task<PaymentIntent> CreatePaymentIntentAsync(CreatePaymentIntentRequest paymentIntentRequest);
        Task<Charge> CreateChargeAsync(string source, decimal amount, string currency);
        Task<Customer> CreateCustomerAsync(string email, string description);
        Task<PaymentIntent> ConfirmPaymentIntentAsync(string paymentIntentId);

        Task<Payment> AddIdOfPayment(Payment payment);
        Task<Payment> GetByIdPayment(int UserId);
        Task<Payment> PaymentIdUpdate(Payment payment);


        }
    }
