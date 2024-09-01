using EntityCommerce;
using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface IOrderService:IGenericService<Order>
    {
        public Task<(Enums.OrderEnum, bool IsSucces)> ShippedGoods(int userId, int goodsId);
        public Task<(Enums.OrderEnum, bool IsSucces)> DeliveredGoods(int userId, int goodsId);
        public Task<Report> ReportGoods(Report report);
    }
}
