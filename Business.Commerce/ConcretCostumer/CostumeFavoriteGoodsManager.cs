using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumeFavoriteGoodsManager : ICostumerFavoriteGoodsService
    {
        private readonly IFavoriteGoodsDal _favoriteGoodsDal;
        private readonly ICostumerGenericRedis<GoodsDto> _genericRedisGoods;
        private readonly IMapper _mapper;

        public CostumeFavoriteGoodsManager(IFavoriteGoodsDal _favoriteGoodsDal
            ,ICostumerGenericRedis<GoodsDto>_genericRedisGoods
            ,IMapper _mappper)
        {
            this._favoriteGoodsDal = _favoriteGoodsDal;
            this._genericRedisGoods = _genericRedisGoods;
            this._mapper = _mappper;
        }

        public async Task<FavoriteGoods> AddFavoriteGoods(FavoriteGoodsDto favoriteGoods)
        {
            var dtoMapper = _mapper.Map<FavoriteGoods>(favoriteGoods);
            var result = await _favoriteGoodsDal.AddFavoriteGoods(dtoMapper);
          
           return result;
        }

        public async Task<List<GoodsDto>> AllListFavoriteGoods(int userId)
        {
           
            var result = await _favoriteGoodsDal.AllListFavoriteGoods(userId);
            var dtoData = _mapper.Map<List<GoodsDto>>(result);
            return dtoData;
        }

        public async Task<(FavoriteGoods, bool IsSuccess)> DeleteFavoriteGoods(int id)
        {
            var result = await _favoriteGoodsDal.DeleteFavoriteGoods(id);
            return result;
        }
    }
}
