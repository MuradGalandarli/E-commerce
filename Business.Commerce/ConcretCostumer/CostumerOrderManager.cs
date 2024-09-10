using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
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
        private readonly IMapper _mapper;
        public CostumerOrderManager(ICostumerOrderDal _costumerOrderDal
            , IMapper _mapper)
        {
            this._costumerOrderDal = _costumerOrderDal;
            this._mapper = _mapper;
        }

        public async Task<(OrderDto, bool IsSuccess)> AddOrder(OrderDto order)
        {
           var orderMap = _mapper.Map<Order>(order);
           var result = await _costumerOrderDal.AddOrder(orderMap); 
            var mapOrder = _mapper.Map<OrderDto>(result.Item1);
            return (mapOrder, result.IsSuccess);
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

    }
}
