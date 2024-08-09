using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shared.Commerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class StripeRepository : IStripeRepository
    {
        /* private readonly string _apiKey;
         private readonly StripeClient _stripeClient;

         public StripeRepository(string apiKey)
         {

             _apiKey = apiKey;
             _stripeClient = new StripeClient(_apiKey);
         }*/
        private readonly StripeClient _stripeClient;
        private readonly ApplicationContext _context;

        public StripeRepository(IConfiguration configuration, ApplicationContext contetx)
        {
            var secretKey = configuration["Stripe:SecretKey"];
            _stripeClient = new StripeClient(secretKey);
            _context = contetx;
        }


        public async Task<PaymentIntent> CreatePaymentIntentAsync(CreatePaymentIntentRequest  paymentIntentRequest)
        {
          //  var OrId = await _context.Orders.FirstOrDefaultAsync(x => x.UserId == paymentIntentRequest.UserId);
            var result = await _context.Goodses.Where(x => x.GoodsId == paymentIntentRequest.GoodsId).Include(x => x.Order).FirstOrDefaultAsync();


            if (result != null )
            {
                foreach (var item in result.Order)
                {
                    if (item.UserId == paymentIntentRequest.UserId && result.Stock - item.NumberOfGoods >= 0 &&
                        item.OrderStatus != Enums.OrderEnum.OutOfStock)
                    {
                        var options = new PaymentIntentCreateOptions
                        {
                            Amount = (long)((result.Price * item.NumberOfGoods) * 100),
                            Currency = paymentIntentRequest.Currency,
                            PaymentMethodTypes = new List<string> { "card" }
                        };
                        
                        var service = new PaymentIntentService(_stripeClient);

                        item.OrderStatus = Enums.OrderEnum.PaymentPending;

                        await _context.SaveChangesAsync();


                        return await service.CreateAsync(options);

                    }
                    item.OrderStatus = Enums.OrderEnum.OutOfStock;
                    _context.SaveChanges();

                }
            }
            return null; 
            
        }

        public async Task<Charge> CreateChargeAsync(string source, decimal amount, string currency)
        {
            var options = new ChargeCreateOptions
            {
                Amount = (long)(amount * 100),
                Currency = currency,
                Source = source
            };

            var service = new ChargeService(_stripeClient);
            return await service.CreateAsync(options);
        }

        public async Task<Customer> CreateCustomerAsync(string email, string description)
        {
            var options = new CustomerCreateOptions
            {
                Email = email,
                Description = description
            };

            var service = new CustomerService(_stripeClient);
            return await service.CreateAsync(options);
        }

        public async Task<PaymentIntent> ConfirmPaymentIntentAsync(string paymentIntentId)
        {
            var service = new PaymentIntentService(_stripeClient);
           var result = await service.ConfirmAsync(paymentIntentId);
           var payId = await _context.Patments.FirstOrDefaultAsync(x => x.PaymentID == paymentIntentId);
            if (payId != null)
            {
               var ordData = await _context.Orders.FirstOrDefaultAsync(x => x.UserId == payId.UserID);
                if (ordData != null)
                {
                    ordData.OrderStatus = Enums.OrderEnum.PaymentCompleted;
                }
            }
            return result;
        }

        public async Task<Payment> AddIdOfPayment(Payment payment)
        {
            if (await GetByIdPayment(payment.UserID) == null)
            {
                
                await _context.Patments.AddAsync(payment);
                await _context.SaveChangesAsync();
                return payment;
            }
            return payment;

        }

        public async Task<Payment> GetByIdPayment(int UserId)
        {
            var result = await _context.Patments.FirstOrDefaultAsync(x => x.UserID == UserId);
            return result;
        }

        public async Task<Payment> PaymentIdUpdate(Payment payment)
        {
            var result =await GetByIdPayment(payment.UserID);
            if (result != null)
            {

                result.PaymentID = payment.PaymentID;
                result.UserID = payment.UserID; 
                result.CustomerID = payment.CustomerID;
                await _context.SaveChangesAsync();
                return payment;
            }
            return payment;
        }

       
    }
}