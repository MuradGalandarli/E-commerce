using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFAnswerRepositoryCostumer : ICostumerAnswerDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFAnswerRepositoryCostumer> _logger;
        public EFAnswerRepositoryCostumer(ApplicationContext context,
            ILogger<EFAnswerRepositoryCostumer> _logger)
        {
            _context = context;
            this._logger = _logger;
        }
        public async Task<Answer> AddAnswer(Answer answer)
        {
<<<<<<< Updated upstream
            var checkUser = await _context.Users.AnyAsync(x => x.UserId == answer.UserId && x.Status == true);
            var checkQuestion = await _context.Questions.AnyAsync(x => x.Status == true);
            if (checkQuestion && checkUser)
=======
            try
>>>>>>> Stashed changes
            {
                var checkUser = await _context.Users.AnyAsync(x => x.UserId == answer.UserId && x.Status == true);
                var checkQuestion = await _context.Questions.AnyAsync(x => x.Status == true);
                if (checkQuestion && checkUser)
                {
                    _context.Answers.Add(answer);
                    await _context.SaveChangesAsync();
                    return answer;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<bool> DeleteAnswer(int id)
        {
<<<<<<< Updated upstream
            var result = await GetAnswer(id);
            if (result != null)
=======
            try
>>>>>>> Stashed changes
            {
                var result = await GetAnswer(id);
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

        public async Task<List<Answer>> GetAllListAnswer()
        {
<<<<<<< Updated upstream
            var result = await _context.Answers.Where(x => x.Status == true).ToListAsync();
            if (result != null)
=======
            try
>>>>>>> Stashed changes
            {
                var result = await _context.Answers.Where(x => x.Status == true).ToListAsync();
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

        public async Task<Answer> GetAnswer(int id)
        {
<<<<<<< Updated upstream
            var result = await _context.Answers.FirstOrDefaultAsync(x => x.AnswerId == id && x.Status == true);
            if (result != null)
=======
            try
>>>>>>> Stashed changes
            {
                var result = await _context.Answers.FirstOrDefaultAsync(x => x.AnswerId == id && x.Status == true);
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

        public async Task<Answer> UpdateAnswer(Answer answer)
        {
            try
            {
<<<<<<< Updated upstream
                result.AnswerDate = answer.AnswerDate;
                result.Status = answer.Status;
                result.AnswerText = answer.AnswerText;

                await _context.SaveChangesAsync();
                return result;
=======
                var result = await this.GetAnswer(answer.AnswerId);
                if (result != null)
                {
                    result.AnswerDate = answer.AnswerDate;
                    result.Status = answer.Status;
                    result.AnswerText = answer.AnswerText;

                    await _context.SaveChangesAsync();
                    return result;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
>>>>>>> Stashed changes
            }
            return null;
        }
        public async Task<Enums.likeEnum> AnswerLikeOrDisLike(AnswerLike answerLike)
        {
            var checkUser = await _context.Users.AnyAsync(x => x.UserId == answerLike.UserId && x.Status == true);
            if (checkUser)
            {
                var answerData = await _context.Answers.FirstOrDefaultAsync(x => x.AnswerId == answerLike.AnswerId && x.Status == true);
                if (answerData != null)
                {

                    {
                        var result = await _context.AnswersLikes.FirstOrDefaultAsync(x => x.UserId == answerLike.UserId && x.AnswerId == answerLike.AnswerId);
                        if (result == null)
                        {
                            await _context.AnswersLikes.AddAsync(answerLike);
                    
                            await _context.SaveChangesAsync();
                        }
                        var changeLikeStatus = await _context.AnswersLikes.FirstOrDefaultAsync(x => x.UserId == answerLike.UserId && x.AnswerId == answerLike.AnswerId);
                    

                        switch (answerLike.LikeOrDisLike)
                        {
                            case Enums.likeEnum.Like:
                                if (changeLikeStatus.LikeStatus == Enums.likeEnum.Neutral)
                                {
                                    answerData.Like += 1;
                                    changeLikeStatus.LikeStatus = Enums.likeEnum.Like;
                                    await _context.SaveChangesAsync();
                                    return Enums.likeEnum.Like;
                                }
                                if (changeLikeStatus.LikeStatus == Enums.likeEnum.Dislike)
                                {
                                    answerData.DisLike -= 1;
                                    answerData.Like += 1;
                                    changeLikeStatus.LikeStatus = Enums.likeEnum.Like;
                                    await _context.SaveChangesAsync();
                                    return Enums.likeEnum.Like;
                                }
                                break;

                            case Enums.likeEnum.Dislike:
                                if (changeLikeStatus.LikeStatus == Enums.likeEnum.Like)
                                {
                                    answerData.Like -= 1;
                                    answerData.DisLike += 1;
                                    changeLikeStatus.LikeStatus = Enums.likeEnum.Dislike;
                                    await _context.SaveChangesAsync();
                                    return Enums.likeEnum.Dislike;
                                }


                                if (changeLikeStatus.LikeStatus == Enums.likeEnum.Neutral)
                                {
                                    answerData.DisLike += 1;
                                    changeLikeStatus.LikeStatus = Enums.likeEnum.Dislike;
                                    await _context.SaveChangesAsync();
                                    return Enums.likeEnum.Dislike;
                                }

                                break;

                            case Enums.likeEnum.Neutral:
                                if (changeLikeStatus.LikeStatus == Enums.likeEnum.Like)
                                {
                                    answerData.Like -= 1;
                                    changeLikeStatus.LikeStatus = Enums.likeEnum.Neutral;
                                    await _context.SaveChangesAsync();
                                    return Enums.likeEnum.Like;
                                }
                                if (changeLikeStatus.LikeStatus == Enums.likeEnum.Dislike)
                                {
                                    answerData.DisLike -= 1;
                                    changeLikeStatus.LikeStatus = Enums.likeEnum.Neutral;
                                    await _context.SaveChangesAsync();
                                    return Enums.likeEnum.Dislike;
                                }

                                break;
                        }
                    }

                }
            }
                    return default;
        }


    }
    }

