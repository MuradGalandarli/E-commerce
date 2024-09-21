using AutoMapper;
using DataTransferObject.EntityDto;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.DtoProfile
{
    public class DtoProfile:Profile
    {
        public DtoProfile()
        {
            CreateMap<FavoriteGoods, FavoriteGoodsDto>();
            CreateMap<FavoriteGoodsDto, FavoriteGoods>();

            CreateMap<Goods, GoodsDto>();
            CreateMap<GoodsDto, Goods>();

            CreateMap<Answer, AnswerDto>();
            CreateMap<AnswerDto, Answer>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();

            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<QuestionDto, Question>();
            CreateMap<Question, QuestionDto>();

            CreateMap<Seller, SellerDto>();
            CreateMap<SellerDto, Seller>();
        }

    }
}
