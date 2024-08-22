﻿using EntityCommerce;
using EntityCommerce.Enum;
using Shared.Commerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerOrderService
    {
        public Task<Enums.OrderEnum> addtoBasket(int id, int number);

        public Task<(Order,bool IsSuccess)>AddOrder(Order order);
        public Task<(Enums.OrderEnum, bool IsSucces)> abilityToTrackOrderStatus(int GoodsId, int UserId);
        public Task<string> EnterTheCoupon(int orderId, string couponCode);

        //  public Task<(Goods, bool IsSuccess)> BuyGoods(BuyGoodsRequest buyGoods);

    }
}
