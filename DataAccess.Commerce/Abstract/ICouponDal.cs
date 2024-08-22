using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface ICouponDal
    {
        public Task<CouponGoods> AddCoupon(CouponGoods coupon);
        public Task<(CouponGoods,bool IsSuccess)> DeleteCoupon(int id);
        public Task<List<CouponGoods>> AllListCoupon();
        public Task<CouponGoods> GetByIdCoupon(int id);
        public Task<CouponGoods> UpdateCoupon(CouponGoods coupon);


    }
}
