using DataAccess.Commerce.Abstract;
using EntityCommerce;
using EntityCommerce.Enum;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerOrderDal : IGeneric<Order>
    {
        public Task<bool> RemoveOrder(int id);
        public Task<List<Order>> getallOrder();
        public Task<Enums.OrderEnum> addToBasket(int id, int number);
        public Task<(Order,bool IsSuccess)> AddOrder(Order order);
        public Task<(Enums.OrderEnum,bool IsSucces)> abilityToTrackOrderStatus(int GoodsId,int UserId);
        public Task<string> EnterTheCoupon(int orderId,string couponCode);

    }
}
