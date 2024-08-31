using DataAccess.Commerce.Abstract;
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

    }
}
