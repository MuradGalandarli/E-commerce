using DataTransferObject.EntityDto;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerGoodsService:IGenericCostumer<GoodsDto>
    {
        public Task<List<GoodsDto>> searchForGoodsByCategory(string category);
        public List<GoodsDto> SearchGoods(GoodsDto goods);
        public Task<string> GetShareLink(int goodsId);
    }
}
