using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class OrderManager : IOrderService
    {
        private readonly ICostumerOrderDal _orderCostmerDal;
        private readonly IOrderDal _orderDal;

        public OrderManager(ICostumerOrderDal _orderCostmerDal, IOrderDal _orderDal)
        {
            this._orderCostmerDal = _orderCostmerDal;
            this._orderDal = _orderDal;
        }

        public async Task<Order> Add(Order t)
        {
           await _orderCostmerDal.Add(t);
            return t;
        }

        public async Task<bool> Delete(int id)
        {
            
         var isTrue = await _orderCostmerDal.RemoveOrder(id);

            return isTrue;
        }

        public async Task<(Enums.OrderEnum, bool IsSucces)> DeliveredGoods(int userId, int goodsId)
        {
            var result = await _orderDal.DeliveredGoods(userId, goodsId); 
            return result;
        }

        public async Task<Order> GetbyId(int id)
        {
           var result = await _orderCostmerDal.GetById(id);
         if(result != null && result.OrderStatus != Enums.OrderEnum.Canceled)
            {
                return result;
            }

            return null;
        }

        public async Task<List<Order>> GetList()
        {
            return await _orderCostmerDal.getallOrder();
        }

        public async Task<Report> ReportGoods(Report report)
        {
            var result = await _orderDal.ReportGoods(report);
            return result;  
        }

        public async Task<(Enums.OrderEnum, bool IsSucces)> ShippedGoods(int userId, int goodsId)
        {
           var result = await _orderDal.ShippedGoods(userId, goodsId);
            return result;
        }

        public async Task<Order> Update(Order t)
        {
           
           await _orderCostmerDal.Update(t);
            return t;
        }
    }
}
