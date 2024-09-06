using Business.Commerce.Abstract;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class GoodsManager : IGoodsService
    {
        private readonly IGoodsDal _goodsDal;
        private readonly ICostumerGenericRedis<Goods> _costumerGenericRedis;

        public GoodsManager(IGoodsDal goodsDal
            , ICostumerGenericRedis<Goods> _costumerGenericRedis)
        {
            _goodsDal = goodsDal;
            this._costumerGenericRedis = _costumerGenericRedis;
        }
        public async Task<Goods> Add(Goods t)
        {
            var result = await _goodsDal.Add(t);
            if (result != null)
            {
                await _costumerGenericRedis.AddListRedis("GetAllGoods", new List<Goods> { result });
            }

            return t;
        }

        public async Task<bool> Delete(int id)
        {

            var isTrue = await _goodsDal.RemoveGoods(id);
            if (isTrue)
            {
                await _costumerGenericRedis.DeleteListRedis("GetAllGoods");
            }
            return isTrue;
        }

        public async Task<Goods> GetbyId(int id)
        {
            var result = await _goodsDal.GetById(id);
            if (result == null)
            {
                return result;
            }
            if (result.Status)
            {
                return result;
            }
            return null;
        }

        public async Task<List<Goods>> GetList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("GetAllGoods");
            if (redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _goodsDal.getallGoods();
            if (result != null)
            {
                var data = await _costumerGenericRedis.AddListRedis("GetAllGoods", result);
            }
            return result;
        }

        public async Task<Goods> Update(Goods t)
        {
            var result = await _goodsDal.Update(t);
            if (result != null)
            {
                await _costumerGenericRedis.DeleteListRedis("GetAllGoods");
            }
            return result;

        }
    }
}
