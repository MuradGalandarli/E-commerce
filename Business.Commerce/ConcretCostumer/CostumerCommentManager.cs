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
        public CostumerCommentManager(ICostumerCommentDal _costumerCommentDal)
        {
            this._costumerCommentDal = _costumerCommentDal;
        }
        public async Task<Comment> CreateComment(Comment comment)
        {
           var result = await _costumerCommentDal.CreateComment(comment);
            return result;  
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
    }
}
