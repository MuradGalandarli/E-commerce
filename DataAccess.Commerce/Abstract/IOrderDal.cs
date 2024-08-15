using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface IOrderDal
    {
        public Task<(Enums.OrderEnum, bool IsSucces)> ShippedGoods(int userId, int goodsId);
        public Task<(Enums.OrderEnum, bool IsSucces)> DeliveredGoods(int userId, int goodsId);
    }
}
