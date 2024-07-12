using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        public async Task<Order> Add(Order t)
        {
           await _orderDal.Add(t);
            return t;
        }

        public async Task Delete(int id)
        {
           await _orderDal.Delete(id);
        }

        public async Task<Order> GetbyId(int id)
        {
           return await _orderDal.GetById(id);
        }

        public async Task<List<Order>> GetList()
        {
            return await _orderDal.GetAll();
        }

        public async Task<Order> Update(Order t)
        {
           
           await _orderDal.Update(t);
            return t;
        }
    }
}
