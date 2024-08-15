using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerCommentService
    {
        public Task<Comment> CreateComment(Comment comment);
        public Task<List<Comment>> GetByIdListCommnt(int goodsId);
        public Task<bool> LikeOrDisLike(int userId, int commentId, int statusLike);
    }
}
