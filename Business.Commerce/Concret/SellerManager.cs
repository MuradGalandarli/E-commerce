using AutoMapper;
using Business.Commerce.Abstract;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.Abstract;
using DataTransferObject.EntityDto;
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
        private readonly ICostumerGenericRedis<SellerDto> _costumerGenericRedis;


        public SellerManager(ISellerDal sellerDal
        , ICostumerGenericRedis<SellerDto> _costumerGenericRedis)
        {
            _sellerDal = sellerDal;
            this._costumerGenericRedis = _costumerGenericRedis;
        }

        public async Task<Seller> Add(Seller t)
        {
            var result = await _sellerDal.Add(t);
            if (result != null)
            {
                await _costumerGenericRedis.DeleteListRedis("SellerRedis");
            }
            return t;
        }

        public async Task<bool> Delete(int id)
        {
            var isTrue = await _sellerDal.RemoveSeller(id);
            if (isTrue)
            {
                await _costumerGenericRedis.DeleteListRedis("SellerRedis");
            }
            return isTrue;
        }

        public async Task<Seller> GetbyId(int id)
        {
            var result = await _sellerDal.GetById(id);

            if (result == null)
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
            var result = await _sellerDal.Update(t);
            if (result != null)
            {
                await _costumerGenericRedis.DeleteListRedis("SellerRedis");
            }
                return t;
        }
    }
}
