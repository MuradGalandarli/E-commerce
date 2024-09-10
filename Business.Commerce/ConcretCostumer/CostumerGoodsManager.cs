using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerGoodsManager:ICostumerGoodsService
    {
        private readonly ICostumerGoodsDal _costumerGoodsyDal;
        private readonly ICostumerGenericRedis<GoodsDto> _costumerGenericRedis;
        private readonly IMapper _mapper;
        public CostumerGoodsManager(ICostumerGoodsDal _costumerGoodsyDal
            , ICostumerGenericRedis<GoodsDto> _costumerGenericRedis
            , IMapper _mapper)
        {
            this._costumerGoodsyDal = _costumerGoodsyDal;
            this._costumerGenericRedis = _costumerGenericRedis;
            this._mapper = _mapper;
        }

        public async Task<List<GoodsDto>> GetAllList()
        {
            
            var redisData = await _costumerGenericRedis.GetListRedis("GetAllGoods");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _costumerGoodsyDal.getAllList();
            var goodsDto = _mapper.Map<List<GoodsDto>>(result);
            await _costumerGenericRedis.AddListRedis("GetAllGoods", goodsDto);
            return goodsDto;
        }

        public async Task<string> GetShareLink(int goodsId)
        {
            var result = await _costumerGoodsyDal.GetShareLink(goodsId);
            return result;
        }

        public async Task<List<GoodsDto>> searchForGoodsByCategory(string category)
        {
            var result = await _costumerGoodsyDal.searchForGoodsByCategory(category);
            var goodsDto = _mapper.Map<List<GoodsDto>>(result);
            return goodsDto;
        }

        public List<GoodsDto> SearchGoods(GoodsDto goods)
        {
            var dtoGoods = _mapper.Map<Goods>(goods);
            var result =  _costumerGoodsyDal.SearchGoods(dtoGoods);
            var goodsDto = _mapper.Map<List<GoodsDto>>(result);
            return goodsDto;
        }
    }
}
