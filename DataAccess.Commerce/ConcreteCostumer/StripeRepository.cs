﻿using DataAccess.Commerce.AbstractCostumer;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class StripeRepository : IStripeRepository
    {

        private readonly StripeClient _stripeClient;
        private readonly ApplicationContext _context;

        public StripeRepository(IConfiguration configuration, ApplicationContext contetx)
        {
            var secretKey = configuration["Stripe:SecretKey"];
            _stripeClient = new StripeClient(secretKey);
            _context = contetx;
        }


        public async Task<PaymentIntent> CreatePaymentIntentAsync(CreatePaymentIntentRequest paymentIntentRequest)
        {
            //  var OrId = await _context.Orders.FirstOrDefaultAsync(x => x.UserId == paymentIntentRequest.UserId);
            var result = await _context.Goodses.Where(x => x.GoodsId == paymentIntentRequest.GoodsId && x.Status == true).
                Include(x => x.Order).Include(x => x.OtherCampaign.Where(x => x.IsDeleted == true && x.EndTime > DateTime.UtcNow)).
                Include(s => s.Campaigns.Where(x => x.IsDeleted == true && x.EndDate > DateTime.UtcNow)).FirstOrDefaultAsync();


            if (result != null)
            {
                (decimal, int) DisCountCampign()
                {
                    foreach (var item in result.Campaigns)
                    {
                        if (item.IsDeleted && item.EndDate > DateTime.UtcNow)
                        {
                            return (item.DiscountRate, item.Id);
                        }
                    }
                    return default;
                }

                decimal Prezent(decimal price, decimal prezent)
                {
                    decimal result = price / 100 * prezent;
                    return result;
                }

                (int numberOfReceipts, int gift, int id) OtherCampaignCount()
                {
                    foreach (var item in result.OtherCampaign)
                    {
                        return (item.NumberOfReceipts, item.GiftNumber, item.OtherCampaignId);
                    }
                    return (default);
                }



                foreach (var item in result.Order)
                {
                    var totalGift = 0;

                    if (OtherCampaignCount().numberOfReceipts > 0)
                    {
                        totalGift += (item.NumberOfGoods / OtherCampaignCount().Item1) * OtherCampaignCount().gift;

                    }
                        int totalNumberOfGoods = item.NumberOfGoods + totalGift;

                        if (item.UserId == paymentIntentRequest.UserId && result.Stock - totalNumberOfGoods >= 0 &&
                            item.OrderStatus != Enums.OrderEnum.OutOfStock)
                        {
                            var disCountCoupon = await _context.CouponGoods.Where(x => x.CouponName == item.CouponName && x.IsDeleted == true).FirstOrDefaultAsync();
                            // decimal Campaignresult = 0;
                            decimal campaignPrezent = 0;

                        if ( DisCountCampign().Item2 != 0)
                            {

                                campaignPrezent += Prezent(result.Price, DisCountCampign().Item1);
                            }

                            decimal Campaignresult = result.Price - campaignPrezent;
                            //decimal campaignPrezentResult = 0;
                            if (item.CouponName != null && disCountCoupon != null)
                            {
                            campaignPrezent += Prezent(Campaignresult, (int)disCountCoupon.Value);
                            } 


                        decimal price = (result.Price - campaignPrezent) * item.NumberOfGoods;

                            var options = new PaymentIntentCreateOptions
                            {
                                Amount = (long)(price * 100),
                                Currency = paymentIntentRequest.Currency,
                                PaymentMethodTypes = new List<string> { "card" }
                            };


                            var service = new PaymentIntentService(_stripeClient);

                            item.NumberOfGoods = (byte)totalNumberOfGoods;
                            item.OrderStatus = Enums.OrderEnum.PaymentPending;
                            item.CouponDiscountedPrice = price;
                            item.CampaignId = DisCountCampign().Item2;
                            item.OtherCampaignId = OtherCampaignCount().id;
                            await _context.SaveChangesAsync();
                            return await service.CreateAsync(options);

                         }

                    item.OrderStatus = Enums.OrderEnum.OutOfStock;
                    await _context.SaveChangesAsync();
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
                    var numberOfGoodsSold = await _context.Goodses.Where(a => a.GoodsId == ordData.GoodsId && a.Status == true).
                        Select(x => x.Stock).FirstOrDefaultAsync();
                    if (numberOfGoodsSold != null)
                    {
                        numberOfGoodsSold = ordData.NumberOfGoods;
                        ordData.OrderStatus = Enums.OrderEnum.PaymentCompleted;
                    }

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
            var result = await GetByIdPayment(payment.UserID);
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