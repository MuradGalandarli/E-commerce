using EntityCommerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface ICouponService:IGenericService<CouponGoods>
    {
        public Task<(CouponGoods, bool IsSuccess)> DeleteCoupon(int id);

    }
}
