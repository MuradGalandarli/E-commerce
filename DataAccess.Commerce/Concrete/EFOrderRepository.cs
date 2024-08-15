using DataAccess.Commerce.Abstract;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
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
        public EFOrderRepository(ApplicationContext _context)
        {
            this._context = _context;
        }
     
        public async Task<(OrderEnum, bool IsSucces)> DeliveredGoods(int userId, int goodsId)
        {
            var result = await _context.Orders.
             Where(x => x.UserId == userId && x.GoodsId == goodsId && x.OrderStatus == Enums.OrderEnum.Shipped).FirstOrDefaultAsync();
            if (result != null)
            {
                result.OrderStatus = Enums.OrderEnum.Delivered;
                await _context.SaveChangesAsync();
                return (Enums.OrderEnum.Delivered, true);
            }
            return (Enums.OrderEnum.Delivered, false);
        }
        public async Task<(OrderEnum, bool IsSucces)> ShippedGoods(int userId, int goodsId)
        {

            var result = await _context.Orders.
            Where(x => x.UserId == userId && x.GoodsId == goodsId && x.OrderStatus == Enums.OrderEnum.PaymentCompleted).FirstOrDefaultAsync();
            if (result != null)
            {
                result.OrderStatus = Enums.OrderEnum.Shipped;
                await _context.SaveChangesAsync();
                return (Enums.OrderEnum.Shipped, true);
            }
            return (Enums.OrderEnum.Shipped, false);
        }
     

    }
}
