using DataAccess.Commerce.AbstractCostumer;
using DataAccess.Commerce.Concrete;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EntityCommerce.Enum.Enums;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFOrderRepositoryCostumer : Generic<Order>, ICostumerOrderDal
    {
        private readonly ApplicationContext _context;
        public EFOrderRepositoryCostumer(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(Order, bool IsSuccess)> AddOrder(Order order)
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



            return (order, false);
        }

        public async Task<Enums.OrderEnum> addToBasket(int id,int number)
        {
            /*
                        var result = await _context.Orders.Where(x => x.GoodsId == id).ToListAsync();
                        foreach (var order in result)
                        {
                            order.OrderStatus = Enums.OrderEnum.AddedToCart;
                        }*/


            var result = await _context.Goodses.Where(x => x.GoodsId == id).Include(a=>a.Order).FirstOrDefaultAsync();
            if (result.Stock - number >= 0)
            {
               
                result.Order.Select(x => x.OrderStatus == Enums.OrderEnum.AddedToCart);
                await _context.SaveChangesAsync();
                return Enums.OrderEnum.AddedToCart;
            }

            result.Order.Select(x => x.OrderStatus == Enums.OrderEnum.OutOfStock);
            return Enums.OrderEnum.OutOfStock;

        }

     /*   public async Task<(Goods, bool IsSuccess)> BuyGoods(BuyGoodsRequest buyGoods)
        {
            
            // _context.Orders.Where(x => x.GoodsId == 5).Include(a=>a.Goodses);
           // var result = await _context.Goodses.Where(x => x.GoodsId == goodsId).Include(x => x.Order).FirstOrDefaultAsync();
            var result = await _context.Goodses.Where(x => x.GoodsId == buyGoods.GoodsId).Include(x => x.Order).FirstOrDefaultAsync();
           
       

            foreach(var item in result.Order)
            {
                if (result.Stock - 8 >= 0 && item.UserId == buyGoods.UserId)
                {
                    item.OrderStatus = Enums.OrderEnum.Purchased;
                    result.Stock -= 8;
                    await _context.SaveChangesAsync();
                    return (result, true);
                }
                item.OrderStatus = Enums.OrderEnum.OutOfStock;
                await _context.SaveChangesAsync();

            }*/



            /*  if ( await result.Select(x => x.Stock - 8).AnyAsync(x => x >= 0))
              {
                  // _context.Orders.Select(x => x.OrderStatus == Enums.OrderEnum.Purchased);
                   result.Select(x => x.order)

                   result.Select(x=>x.Stock - number);
                  await _context.SaveChangesAsync();
                  return (await result.FirstOrDefaultAsync(), true);
              }
              _context.Orders.Select(x => x.OrderStatus == Enums.OrderEnum.Purchased);
              await _context.SaveChangesAsync();*/

          /*  return (result, false);
        }*/

        public async Task<List<Order>> getallOrder()
        {
            var data = await _context.Orders.Where(x => x.OrderStatus == Enums.OrderEnum.AddedToCart).ToListAsync();
            return data;
        }

        public async Task<bool> RemoveOrder(int id)
        {
            var data = await _context.Orders.FindAsync(id);
            if (data != null)
            {
                data.OrderStatus = Enums.OrderEnum.Canceled;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }



    }
}
