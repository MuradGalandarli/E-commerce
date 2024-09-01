using DataAccess.Commerce.Abstract;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Stripe.TestHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static EntityCommerce.Enum.Enums;

namespace DataAccess.Commerce.Concrete
{
    public class EFOrderRepository : IOrderDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFOrderRepository> _logger;
        public EFOrderRepository(ApplicationContext _context,
             ILogger<EFOrderRepository> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        public async Task<(OrderEnum, bool IsSucces)> DeliveredGoods(int userId, int goodsId)
        {
            try
            {
                var result = await _context.Orders.
                 Where(x => x.UserId == userId && x.GoodsId == goodsId && x.OrderStatus == Enums.OrderEnum.Shipped).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.OrderStatus = Enums.OrderEnum.Delivered;
                    await _context.SaveChangesAsync();
                    return (Enums.OrderEnum.Delivered, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return (Enums.OrderEnum.Delivered, false);
        }
        public async Task<(OrderEnum, bool IsSucces)> ShippedGoods(int userId, int goodsId)
        {
            try
            {
                var result = await _context.Orders.
                Where(x => x.UserId == userId && x.GoodsId == goodsId && x.OrderStatus == Enums.OrderEnum.PaymentCompleted).FirstOrDefaultAsync();
                if (result != null)
                {
                    result.OrderStatus = Enums.OrderEnum.Shipped;
                    await _context.SaveChangesAsync();
                    return (Enums.OrderEnum.Shipped, true);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return (Enums.OrderEnum.Shipped, false);
        }

        public async Task<Report> ReportGoods(Report report)
        {
            try
            {
                var query = _context.Orders.AsQueryable();
                if (report.GoodsID == 0)
                {
                    var totalStockSellerId = _context.Goodses.Where(x => x.SellerId == report.SellerId).Sum(x => x.Stock);

                    var goodsId = _context.Goodses.Where(x => x.SellerId == report.SellerId).Select(x => x.GoodsId).ToList();

                    if (report.StartDay.HasValue && report.EndDay.HasValue)
                    {
                        var Timedata = query.Where(x => x.SellerTime <= report.EndDay && x.SellerTime >= report.StartDay && goodsId.Contains(x.GoodsId)
                        && x.OrderStatus == Enums.OrderEnum.PaymentCompleted)
                              .Select(x => new
                              {
                                  x.NumberOfGoods,
                                  x.CouponDiscountedPrice
                              }).ToList();
                        foreach (var item in Timedata)
                        {
                            report.NumberSold += item.NumberOfGoods;
                            report.TotalPrice += item.CouponDiscountedPrice ?? 0m;
                        }
                            report.RemainingInStock = totalStockSellerId.Value;
                        await _context.AddAsync(report);
                        await _context.SaveChangesAsync();
                        return report;
                    }



                    var data = query.Where(x => goodsId.Contains(x.GoodsId) && x.OrderStatus == Enums.OrderEnum.PaymentCompleted)
                      .Select(x => new
                      {
                          x.NumberOfGoods,
                          x.CouponDiscountedPrice
                      }).ToList();
                    foreach (var item in data)
                    {
                        report.NumberSold += item.NumberOfGoods;
                        report.TotalPrice += item.CouponDiscountedPrice ?? 0m;
                    }
                        report.RemainingInStock = totalStockSellerId.Value;
                    await _context.AddAsync(report);
                    await _context.SaveChangesAsync();
                    return report;

                }
                var IsSuccess = await _context.Orders.AnyAsync(x => x.OrderStatus == Enums.OrderEnum.PaymentCompleted && x.GoodsId == report.GoodsID);
                if (IsSuccess)
                {
                    var totalStock = _context.Goodses.Where(x => x.GoodsId == report.GoodsID).Sum(x => x.Stock);

                    if (report.StartDay.HasValue && report.EndDay.HasValue)
                    {
                        var dateOrder = query.Where(x => x.GoodsId == report.GoodsID && x.OrderStatus == Enums.OrderEnum.PaymentCompleted
                         && x.SellerTime >= report.StartDay && x.SellerTime <= report.EndDay)
                           .Select(x => new
                           {
                               x.NumberOfGoods,
                               x.CouponDiscountedPrice
                           }).ToList();
                        foreach (var item in dateOrder)
                        {
                            report.NumberSold += item.NumberOfGoods;
                            report.TotalPrice += item.CouponDiscountedPrice ?? 0m;
                        }
                            report.RemainingInStock = totalStock.Value;
                        await _context.AddAsync(report);
                        await _context.SaveChangesAsync();
                        return report;
                    }

                    var result = query.Where(x => x.GoodsId == report.GoodsID && x.OrderStatus == Enums.OrderEnum.PaymentCompleted)
                      .Select(x => new
                      {
                          x.NumberOfGoods,
                          x.CouponDiscountedPrice
                      }).ToList();

                    foreach (var item in result)
                    {
                        report.NumberSold += item.NumberOfGoods;
                        report.TotalPrice += item.CouponDiscountedPrice ?? 0m;
                    }
                        report.RemainingInStock = totalStock.Value;
                    await _context.AddAsync(report);
                    await _context.SaveChangesAsync();
                    return report;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

    }
}
