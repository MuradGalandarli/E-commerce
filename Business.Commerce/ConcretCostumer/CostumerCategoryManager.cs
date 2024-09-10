using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerCategoryManager : ICostumerCategorySevice
    {
        private readonly ICostumerCategoryDal _costumerCategoryDal;
        private readonly ICostumerGenericRedis<CategoryDto> _genericCostumerRedis;
        private readonly IMapper _mapper;
        public CostumerCategoryManager(ICostumerCategoryDal _costumerCategoryDal
            ,ICostumerGenericRedis<CategoryDto> _genericCostumerRedis
            , IMapper _mapper)
        {
            this._costumerCategoryDal = _costumerCategoryDal;
            this._genericCostumerRedis = _genericCostumerRedis; 
            this._mapper = _mapper;
        }
        public async Task<List<CategoryDto>> GetAllList() 
        {
            
            var getRedis = await _genericCostumerRedis.GetListRedis("GetAllCategory");
            if (getRedis != null && getRedis.Count > 0)
            {
                return getRedis;
            }

            var data = await _costumerCategoryDal.getAllList();
            var  categoryDto = _mapper.Map<CategoryDto>(data); 
            await _genericCostumerRedis.AddListRedis("GetAllCategory",new List<CategoryDto> { categoryDto });
            return new List<CategoryDto> { categoryDto };

        }
    }
}
