using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFQuestionRepositoryCostumer : ICostumerQuestionDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFQuestionRepositoryCostumer> _logger;
        public EFQuestionRepositoryCostumer(ApplicationContext _context
            , ILogger<EFQuestionRepositoryCostumer> logger)
        {
            this._context = _context;
            _logger = logger;
        }
        public async Task<Question> AddQuestion(Question question)
        {
            var checkUser = await _context.Users.AnyAsync(x => x.UserId == question.UserId && x.Status == true);
            try
            {
                if (checkUser)
                {
                    _context.Questions.Add(question);
                    await _context.SaveChangesAsync();
                    return question;
                }
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
            }

            return null;
        }

        public async Task<bool> DeleteQuestion(int id)
        {
            try
            {
                var result = await this.GetQuestion(id);
                if (result != null)
                {
                    result.Status = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return false;
        }

        public async Task<List<Question>> GetAllListQuestion()
        {
            try
            {
                var result = await _context.Questions.Where(x => x.Status == true).ToListAsync();
                if (result != null)
                {
                    return result;
                }
            }
            catch (Exception ex) 
            { 
            _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<Question> GetQuestion(int id)
        {
            try
            {
                var result = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == id && x.Status == true);
                if (result != null)
                {
                    return result;
                }
            }
            catch(Exception ex)
            { 
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<Enums.likeEnum> QuestionLikeOrDisLike(QuestionLike questionLike)
        {
            var checkUser = await _context.Users.AnyAsync(x => x.UserId == questionLike.UserId && x.Status == true);
            if (checkUser)
            {
                var questionData = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == questionLike.QuestionId && x.Status == true);
                if (questionData != null)
                {
                    var result = await _context.QuestionLikes.FirstOrDefaultAsync(x => x.UserId == questionLike.UserId && x.QuestionId == questionLike.QuestionId);
                    if (result == null)
                    {
                        var create = await _context.QuestionLikes.AddAsync(questionLike);
                        //     questionLike.LikeStatus = Enums.likeEnum.Neutral;
                        await _context.SaveChangesAsync();
                    }
                    var changeLikeStatus = await _context.QuestionLikes.FirstOrDefaultAsync(x => x.UserId == questionLike.UserId && x.QuestionId == questionLike.QuestionId);


                    switch (questionLike.LikeOrDisLike)
                    {
                        case Enums.likeEnum.Like:
                            if (changeLikeStatus.LikeStatus == Enums.likeEnum.Neutral)
                            {
                                questionData.Like += 1;
                                changeLikeStatus.LikeStatus = Enums.likeEnum.Like;
                                await _context.SaveChangesAsync();
                                return Enums.likeEnum.Like;
                            }
                            if (changeLikeStatus.LikeStatus == Enums.likeEnum.Dislike)
                            {
                                questionData.DisLike -= 1;
                                questionData.Like += 1;
                                changeLikeStatus.LikeStatus = Enums.likeEnum.Like;
                                await _context.SaveChangesAsync();
                                return Enums.likeEnum.Like;
                            }
                            break;

                        case Enums.likeEnum.Dislike:
                            if (changeLikeStatus.LikeStatus == Enums.likeEnum.Like)
                            {
                                questionData.Like -= 1;
                                questionData.DisLike += 1;
                                changeLikeStatus.LikeStatus = Enums.likeEnum.Dislike;
                                await _context.SaveChangesAsync();
                                return Enums.likeEnum.Dislike;
                            }


                            if (changeLikeStatus.LikeStatus == Enums.likeEnum.Neutral)
                            {
                                questionData.DisLike += 1;
                                changeLikeStatus.LikeStatus = Enums.likeEnum.Dislike;
                                await _context.SaveChangesAsync();
                                return Enums.likeEnum.Dislike;
                            }

                            break;

                        case Enums.likeEnum.Neutral:
                            if (changeLikeStatus.LikeStatus == Enums.likeEnum.Like)
                            {
                                questionData.Like -= 1;
                                changeLikeStatus.LikeStatus = Enums.likeEnum.Neutral;
                                await _context.SaveChangesAsync();
                                return Enums.likeEnum.Like;
                            }
                            if (changeLikeStatus.LikeStatus == Enums.likeEnum.Dislike)
                            {
                                questionData.DisLike -= 1;
                                changeLikeStatus.LikeStatus = Enums.likeEnum.Neutral;
                                await _context.SaveChangesAsync();
                                return Enums.likeEnum.Dislike;
                            }

                            break;
                    }
                }
            }
            return default;

        }

        public async Task<Question> UpdateQuestion(Question question)
        {
            try
            {
                var result = await this.GetQuestion(question.QuestionId);
                if (result != null)
                {
                    result.QuestionDate = question.QuestionDate;
                    result.Status = question.Status;
                    result.QuestionText = question.QuestionText;

                    await _context.SaveChangesAsync();
                    return result;
                }
            }
            catch(Exception ex)
            {
                  _logger.LogError(ex.ToString());
            }

            return null;
        }
    }
}
