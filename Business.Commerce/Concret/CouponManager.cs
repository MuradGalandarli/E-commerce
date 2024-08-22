using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;

namespace Business.Commerce.Concret
{
    public class CouponManager : ICouponService
    {
          private readonly ICouponDal _couponDal;
          public CouponManager(ICouponDal _couponDa)
          {
              this._couponDal = _couponDa;
          }
       

        public async Task<CouponGoods> Add(CouponGoods t)
        {
            var result = await _couponDal.AddCoupon(t);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(CouponGoods, bool IsSuccess)> DeleteCoupon(int id)
        {
            var result = await _couponDal.DeleteCoupon(id);
            return result;
        }

        public async Task<CouponGoods> GetbyId(int id)
        {
            var result = await _couponDal.GetByIdCoupon(id);
            return result;
        }

        public async Task<List<CouponGoods>> GetList()
        {
            var result = await _couponDal.AllListCoupon();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<CouponGoods> Update(CouponGoods t)
        {
           var result = await _couponDal.UpdateCoupon(t); 
            return result;
        }
    }
}
