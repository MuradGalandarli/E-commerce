using AutoMapper;
using DataTransferObjects.Commerce.DtoEntity;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects.Commerce.DtoProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<FavoriteGoods, FavoriteGoodsDto>();
            CreateMap<FavoriteGoodsDto, FavoriteGoods>();
        }
    }
}
