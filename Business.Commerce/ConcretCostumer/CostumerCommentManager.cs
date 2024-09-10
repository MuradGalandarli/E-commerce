using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerCommentManager : ICostumerCommentService
    {
        private readonly ICostumerCommentDal _costumerCommentDal;
        private readonly ICostumerGenericRedis<CommentDto> _costumerGenericRedis;
        private readonly IMapper _mapper;
        public CostumerCommentManager(ICostumerCommentDal _costumerCommentDal
            , ICostumerGenericRedis<CommentDto> costumerGenericRedis
            , IMapper _mapper)
        {
            this._costumerCommentDal = _costumerCommentDal;
            _costumerGenericRedis = costumerGenericRedis;
            this._mapper = _mapper;
        }

        public async Task<CommentDto> CreateComment(CommentDto comment)
        {
            var commentDto = _mapper.Map<Comment>(comment);
            var result = await _costumerCommentDal.CreateComment(commentDto);
            var dtoComment = _mapper.Map<CommentDto>(result);
            if (result != null)
            {
                await _costumerGenericRedis.AddListRedis("Comment", new List<CommentDto> { dtoComment });
            }
            return dtoComment;
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var IsDelete = await _costumerCommentDal.DeleteComment(commentId);
            if (IsDelete)
            {
                await _costumerGenericRedis.DeleteListRedis("Comment");
            }
            return IsDelete;
        }

        public async Task<List<CommentDto>> GetAllComment()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("Comment");
            if (redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var data = await _costumerCommentDal.GetAllComment();
            var commentDto = _mapper.Map<List<CommentDto>>(data);
            if (data != null && data.Count > 0)
            {   

                await _costumerGenericRedis.AddListRedis("Comment", commentDto);
                return commentDto;
            }
            return null;
        }

        public async Task<List<CommentDto>> GetByIdListCommnt(int goodsId)
        {
            var result = await _costumerCommentDal.GetByIdListCommnt(goodsId);
            var commentDto = _mapper.Map<List<CommentDto>>(result);
            return commentDto;
        }

        public async Task<bool> LikeOrDisLike(int userId, int commentId, int statusLike)
        {
            var result = await _costumerCommentDal.LikeOrDisLike(userId, commentId, statusLike);
            return result;
        }

        public async Task<CommentDto> UpdateComment(CommentDto comment)
        {
            var commentDto = _mapper.Map<Comment>(comment);
            var updateData = await _costumerCommentDal.Update(commentDto);
            if (updateData != null)
            {
                await _costumerGenericRedis.DeleteListRedis("Comment");
            }
            var omment = _mapper.Map<Comment>(comment);
            var Dtoomment = _mapper.Map<CommentDto>(updateData);

            return Dtoomment;
        }

    }
}
