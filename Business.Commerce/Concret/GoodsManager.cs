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
    public class GoodsManager : IGoodsService
    {
        private readonly IGoodsDal _goodsDal;

        public GoodsManager(IGoodsDal goodsDal)
        {
            _goodsDal = goodsDal;
        }
        public async Task<Goods> Add(Goods t)
        {
           await _goodsDal.Add(t);
            return t;
        }

        public async Task Delete(int id)
        {
           await _goodsDal.Delete(id);
        }

        public async Task<Goods> GetbyId(int id)
        {
          return await _goodsDal.GetById(id);
        }

        public async Task<List<Goods>> GetList()
        {
            return await  _goodsDal.GetAll();
        }

        public async Task<Goods> Update(Goods t)
        {
           return await _goodsDal.Update(t);

        }
    }
}
