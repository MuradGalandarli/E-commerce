using DataTransferObject.EntityDto;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerSellerService:IGenericCostumer<SellerDto>
    {
        public Task<SellerDto> GetById(int id);
        public Task<List<GoodsDto>> GetListSellerGoods(int sellerId);
    }
}
