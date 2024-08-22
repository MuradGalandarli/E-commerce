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

        /*  public Task<Coupon> AddCoupon(Coupon coupon);
          public Task<(Coupon, bool IsSuccess)> DeleteCoupon(int id);
          public Task<List<Coupon>> AllListCoupon();
          public Task<Coupon> GetByIdCoupon(int id);
          public Task<Coupon> UpdateCoupon(Coupon coupon);*/
    }
}
