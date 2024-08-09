using Business.Commerce.Abstract;
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
        private readonly ICostumerOrderDal _orderDal;

        public OrderManager(ICostumerOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<Order> Add(Order t)
        {
           await _orderDal.Add(t);
            return t;
        }

        public async Task<bool> Delete(int id)
        {
            
         var isTrue = await _orderDal.RemoveOrder(id);

            return isTrue;
        }

        public async Task<Order> GetbyId(int id)
        {
           var result = await _orderDal.GetById(id);
         if(result != null && result.OrderStatus != Enums.OrderEnum.Canceled)
            {
                return result;
            }

           /* if (result.OrderStatus)
            {
                return result;
            }*/
            return null;
        }

        public async Task<List<Order>> GetList()
        {
            return await _orderDal.getallOrder();
        }

        public async Task<Order> Update(Order t)
        {
           
           await _orderDal.Update(t);
            return t;
        }
    }
}
