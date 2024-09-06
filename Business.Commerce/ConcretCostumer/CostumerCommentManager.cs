using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
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
        private readonly ICostumerGenericRedis<Comment> _costumerGenericRedis;
        public CostumerCommentManager(ICostumerCommentDal _costumerCommentDal
            , ICostumerGenericRedis<Comment> costumerGenericRedis)
        {
            this._costumerCommentDal = _costumerCommentDal;
            _costumerGenericRedis = costumerGenericRedis;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
           var result = await _costumerCommentDal.CreateComment(comment);
            if(result != null)
            {
                await _costumerGenericRedis.AddListRedis("Comment",new List<Comment>{ result});
            }
            return result;  
        }

        public async Task<bool> DeleteComment(int commentId)
        {
            var IsDelete = await _costumerCommentDal.DeleteComment(commentId);
            if(IsDelete)
            {
                await _costumerGenericRedis.DeleteListRedis("Comment");
            }
            return IsDelete;
        }

        public async Task<List<Comment>> GetAllComment()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("Comment");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var data = await _costumerCommentDal.GetAllComment();
            if (data != null && data.Count > 0)
            {
                await _costumerGenericRedis.AddListRedis("Comment", data);
                return data;
            }
            return null;
        }

        public async Task<List<Comment>> GetByIdListCommnt(int goodsId)
        {
            var result = await _costumerCommentDal.GetByIdListCommnt(goodsId);
            return result;
        }

        public async Task<bool> LikeOrDisLike(int userId, int commentId, int statusLike)
        {
            var result = await _costumerCommentDal.LikeOrDisLike(userId, commentId, statusLike);    
            return result;  
        }

        public async Task<Comment> UpdateComment(Comment comment)
        {
            var updateData = await _costumerCommentDal.Update(comment);
            if (updateData != null)
            {
                await _costumerGenericRedis.DeleteListRedis("Comment");
            }
            return updateData;
        }

    }
}
