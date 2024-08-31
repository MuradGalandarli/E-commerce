using DataAccess.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using DataAccess.Commerce.Concrete;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFCommentRepositoryCostumer : Generic<Comment>, ICostumerCommentDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFCommentRepositoryCostumer> _logger;
        public EFCommentRepositoryCostumer(ApplicationContext context
            , ILogger<EFCommentRepositoryCostumer> _logger) : base(context,_logger)
        {
            _context = context;
            this._logger = _logger;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            try
            {
                var result = await _context.Orders.Where(x => x.UserId == comment.UserId && x.GoodsId == comment.GoodsId).Select(o => o.OrderStatus).FirstOrDefaultAsync();
                if (result == Enums.OrderEnum.Delivered)
                {
                    comment.CreatedAt = DateTime.UtcNow;
                    await _context.Comments.AddAsync(comment);
                    await _context.SaveChangesAsync();
                    return comment;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<List<Comment>> GetByIdListCommnt(int goodsId)
        {
            try
            {
                var result = await _context.Comments.Where(x => x.GoodsId == goodsId && x.IsDeleted == true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<bool> LikeOrDisLike(int userId, int commentId, int statusLike)
        {
            try
            {
                var result = await _context.Comments.Where(x => x.Id == commentId && x.IsDeleted == true).FirstOrDefaultAsync();
                if (result != null)
                {
                    var checkLike = await _context.Lieks.Where(x => x.CommentId == commentId && x.UserId == userId).FirstOrDefaultAsync();

                    if (checkLike == null)
                    {

                        Like likeobj = new Like()
                        {
                            CommentId = commentId,
                            UserId = userId


                        };
                        await _context.AddAsync(likeobj);
                        await _context.SaveChangesAsync();

                    }
                }
                var like = await _context.Lieks.Where(x => x.CommentId == commentId && x.UserId == userId).FirstOrDefaultAsync();
                switch (statusLike)
                {

                    case (int)Enums.likeEnum.Dislike:
                        if (like.StatusLike != (int)Enums.likeEnum.Dislike)
                        {
                            if (like.StatusLike == (int)Enums.likeEnum.Like)
                            {
                                result.LikeCount -= 1;
                            }
                            result.DisLikeCount += 1;
                            like.StatusLike = (int)Enums.likeEnum.Dislike;
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        break;
                    case (int)Enums.likeEnum.Like:
                        if (like.StatusLike != (int)Enums.likeEnum.Like)
                        {
                            if (like.StatusLike == (int)Enums.likeEnum.Dislike)
                            {
                                result.DisLikeCount -= 1;
                            }
                            result.LikeCount += 1;
                            like.StatusLike = (int)Enums.likeEnum.Like;
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        break;

                    case (int)Enums.likeEnum.Neutral:
                        if (like.StatusLike == (int)Enums.likeEnum.Dislike)
                        {
                            result.DisLikeCount -= 1;
                            like.StatusLike = (int)Enums.likeEnum.Neutral;
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        else if (like.StatusLike == (int)Enums.likeEnum.Like)
                        {
                            result.LikeCount -= 1;
                            like.StatusLike = (int)Enums.likeEnum.Neutral;
                            await _context.SaveChangesAsync();
                            return true;
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return false;
        }

    }
}
