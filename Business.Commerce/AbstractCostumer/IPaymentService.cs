using EntityCommerce;
using Shared.Commerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface IPaymentService
    {
        /*   Task<PaymentIntent> CreatePaymentIntentAsync(decimal amount, string currency);
           Task<Charge> CreateChargeAsync(string source, decimal amount, string currency);
           Task<Customer> CreateCustomerAsync(string email, string description);
           Task<PaymentIntent> ConfirmPaymentIntentAsync(string paymentIntentId);*/

        public Task<PaymentIntent> CreatePayment(CreatePaymentIntentRequest paymentIntentRequest);
        public Task<Charge> ChargeCustomer(string source, decimal amount, string currency);
        public Task<Customer> RegisterCustomer(string email, string description);
        public Task<PaymentIntent> ConfirmPayment(string paymentIntentId);
        Task<Payment> AddIdOfPayment(Payment payment);
        Task<Payment> GetByIdPayment(int UserId);
        Task<Payment> PaymentUpdate(Payment payment);
        public Task<Refund> RefundPaymentAsync(int userId, int goodsId);

    }
}
