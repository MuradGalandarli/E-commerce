using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerOrderManager : ICostumerOrderService
    {
        private readonly ICostumerOrderDal _costumerOrderDal;
        public CostumerOrderManager(ICostumerOrderDal _costumerOrderDal)
        {
            this._costumerOrderDal = _costumerOrderDal;
        }

        public async Task<(Order, bool IsSuccess)> AddOrder(Order order)
        {
           var result = await _costumerOrderDal.AddOrder(order); 
            return result;
        }

        public async Task<Enums.OrderEnum> addtoBasket(int id, int number)
        {
          var result = await _costumerOrderDal.addToBasket(id,number);
            return result;

        }

        public async Task<(Enums.OrderEnum, bool IsSucces)> abilityToTrackOrderStatus(int GoodsId, int UserId)
        {
           var result = await _costumerOrderDal.abilityToTrackOrderStatus(GoodsId, UserId);
            return result;  
        }

        public async Task<string> EnterTheCoupon(int orderId, string couponCode)
        {
           var result = await _costumerOrderDal.EnterTheCoupon(orderId, couponCode);    
            return result;
        }

        /* public async Task<(Goods, bool IsSuccess)> BuyGoods(BuyGoodsRequest buyGoods)
         {
           var result =await _costumerOrderDal.BuyGoods(buyGoods); 
           return (result.Item1,result.IsSuccess);   
         }*/
    }
}
