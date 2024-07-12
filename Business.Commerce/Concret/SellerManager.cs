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
    public class SellerManager : IGenericService<Seller>
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

        public async Task Delete(int id)
        {
           await _sellerDal.Delete(id);
            
        }

        public async Task<Seller> GetbyId(int id)
        {
        return await _sellerDal.GetById(id);
        }

        public async Task<List<Seller>> GetList()
        {
          return await _sellerDal.GetAll();
        }

        public async Task<Seller> Update(Seller t)
        {
           await _sellerDal.Update(t);
            return t;   
        }
    }
}
