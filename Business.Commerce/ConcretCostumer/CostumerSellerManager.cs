using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using Stripe.Tax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerSellerManager : ICostumerSellerService
    {
        private readonly ICostumerSellerDal _costumerSellerDal;
        private readonly IMapper _mapper;
        private readonly CostumerRedisManager<SellerDto> _costumerRedisSeller;
        public CostumerSellerManager(ICostumerSellerDal _costumerSellerDal
            , IMapper _mapper
            , CostumerRedisManager<SellerDto> _costumerRedisSeller)
        {
            this._costumerSellerDal = _costumerSellerDal;  
            this._mapper = _mapper;
            this._costumerRedisSeller = _costumerRedisSeller;
        }
        public async Task<List<SellerDto>> GetAllList()
        {
            var redisData = await _costumerRedisSeller.GetListRedis("SellerRedis");
            if (redisData != null)
            {
                return redisData;
            }

            var result = await _costumerSellerDal.GetAllListSeller();
            if(result != null)
            {
                var mapSeller = _mapper.Map<List<SellerDto>>(result);
                await _costumerRedisSeller.AddListRedis("SellerRedis", mapSeller);
                return mapSeller;
            }
            return null;
        }

        public async Task<SellerDto> GetById(int id)
        {
            var result = await _costumerSellerDal.GetById(id);
            if (result != null)
            {
                var mapSeller = _mapper.Map<SellerDto>(result);
                return mapSeller;
            }
            return null;
        }

        public async Task<List<GoodsDto>> GetListSellerGoods(int sellerId)
        {
           
            var result = await _costumerSellerDal.GetListSellerGoods(sellerId);
            if (result != null)
            {
                var mapGoods = _mapper.Map<List<GoodsDto>>(result);
                return mapGoods;
            }
            return null;
        }
    }
}
