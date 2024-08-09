using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class SellerManager : ISellerService
    {
        private readonly ISellerDal _sellerDal;

        public SellerManager(ISellerDal sellerDal)
        {
            _sellerDal = sellerDal;
        }

        public async Task<Seller> Add(Seller t)
        {
          await _sellerDal.Add(t);
            return t;
        }

        public async Task<bool> Delete(int id)
        {
           var isTrue = await _sellerDal.RemoveSeller(id);
            return isTrue;
        }

        public async Task<Seller> GetbyId(int id)
        {
        var result = await _sellerDal.GetById(id);

            if (result == null )
            {
                return null;
            }

            if (result.Status)
            {
                return result;
            }
            return null;
        }

        public async Task<List<Seller>> GetList()
        {
          return await _sellerDal.getallSeller();
        }

        public async Task<Seller> Update(Seller t)
        {
           await _sellerDal.Update(t);
            return t;   
        }
    }
}
