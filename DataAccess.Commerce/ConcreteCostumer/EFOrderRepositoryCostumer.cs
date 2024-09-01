using DataAccess.Commerce.AbstractCostumer;
using DataAccess.Commerce.Concrete;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Commerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityCommerce.Enum.Enums;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFOrderRepositoryCostumer : Generic<Order>, ICostumerOrderDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFOrderRepositoryCostumer> _logger;
        public EFOrderRepositoryCostumer(ApplicationContext context
            , ILogger<EFOrderRepositoryCostumer> _logger) : base(context, _logger)
        {
            _context = context;
            this._logger = _logger;
        }

        public async Task<(OrderEnum, bool IsSucces)> abilityToTrackOrderStatus(int GoodsId, int UserId)
        {
            try
            {
                var result = await _context.Orders.FirstOrDefaultAsync(x => x.GoodsId == GoodsId && x.UserId == UserId);
                if (result != null)
                {
                    return (result.OrderStatus, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return (default, false);
        }

        public async Task<(Order, bool IsSuccess)> AddOrder(Order order)
        {
            try
            {
                var resultList = await _context.Orders.Where(x => x.UserId == order.UserId).ToListAsync();


                int saygac = 0;
                foreach (var item in resultList)
                {
                    if (item.GoodsId == order.GoodsId)
                    {
                        saygac++;
                        break;
                    }

                }
                if (saygac <= 0)
                {
                    order.OrderStatus = Enums.OrderEnum.AddedToCart;
                    await _context.Orders.AddAsync(order);
                    await _context.SaveChangesAsync();
                    return (order, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message}");
            }

            return (order, false);
        }

        public async Task<Enums.OrderEnum> addToBasket(int id, int number)
        {
            try
            {
                var result = await _context.Goodses.Where(x => x.GoodsId == id).Include(a => a.Order).FirstOrDefaultAsync();
                if (result.Stock - number >= 0)
                {

                    result.Order.Select(x => x.OrderStatus == Enums.OrderEnum.AddedToCart);
                    await _context.SaveChangesAsync();
                    return Enums.OrderEnum.AddedToCart;
                }

                result.Order.Select(x => x.OrderStatus == Enums.OrderEnum.OutOfStock);
                return Enums.OrderEnum.OutOfStock;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return default;
        }

        public async Task<string> EnterTheCoupon(int orderId, string couponCode)
        {
            try
            {
                var checkCoupon = await _context.CouponGoods.AnyAsync
                    (x => x.CouponName == couponCode && x.IsDeleted == true && x.EndDate > DateTime.UtcNow && x.Value > 0);
                if (checkCoupon)
                {


                    var IsSuccess = await _context.Orders.AnyAsync
                    (x => x.OrderStatus != Enums.OrderEnum.Canceled && x.NumberOfGoods > 0);
                    if (IsSuccess)
                    {
                        var data = await _context.CouponGoods.Where
                            (x => x.CouponName == couponCode && x.IsDeleted == true && x.EndDate > DateTime.UtcNow).FirstOrDefaultAsync();
                        if (data != null)
                        {
                            var result = await _context.Orders.FindAsync(orderId);
                            result.CouponName = couponCode;
                            result.CouponId = data.CouponGoodsId;
                            await _context.SaveChangesAsync();
                            return result.CouponName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }


        public async Task<List<Order>> getallOrder()
        {
            try
            {
                var data = await _context.Orders.Where(x => x.OrderStatus == Enums.OrderEnum.AddedToCart).ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<bool> RemoveOrder(int id)
        {
            try
            {
                var data = await _context.Orders.FindAsync(id);
                if (data != null)
                {
                    data.OrderStatus = Enums.OrderEnum.Canceled;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

      
    }
}