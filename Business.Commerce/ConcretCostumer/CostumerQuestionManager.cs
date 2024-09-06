using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerQuestionManager : ICostumerQuestionService
    {
        private readonly ICostumerQuestionDal _costumerQuestionDal;
        private readonly ICostumerGenericRedis<Question> _costumerGenericRedis;
        public CostumerQuestionManager(ICostumerQuestionDal _costumerQuestionDal
            , ICostumerGenericRedis<Question> _costumerGenericRedis)
        {
            this._costumerQuestionDal = _costumerQuestionDal;
            this._costumerGenericRedis = _costumerGenericRedis;
        }

        public async Task<Question> Add(Question t)
        {

            var result = await _costumerQuestionDal.AddQuestion(t);
            if (result != null)
            {
                await _costumerGenericRedis.AddListRedis("Question",new List<Question> { result });
            }
            return result;
        }

        public async Task<bool> Delete(int id)
        {
          var IsSuccess = await  _costumerQuestionDal.DeleteQuestion(id);
            if(IsSuccess)
            {
                await _costumerGenericRedis.DeleteListRedis("Question");
            }

            return IsSuccess;
        }

        public Task<Question> GetbyId(int id)
        {
            var result = _costumerQuestionDal.GetQuestion(id);
            return result;
        }

        public async Task<List<Question>> GetList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("Question");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
           var result = await _costumerQuestionDal.GetAllListQuestion();
            if(result != null)
            {
                await _costumerGenericRedis.AddListRedis("Question", result);
            }
            return result;
        }

        public async Task<Enums.likeEnum> QuestionLikeOrDisLike(QuestionLike questionLike)
        {
            var result = await _costumerQuestionDal.QuestionLikeOrDisLike(questionLike);
            return result;
        }

        public async Task<Question> Update(Question t)
        {
            var result = await _costumerQuestionDal.UpdateQuestion(t);
            if(result != null)
            {
                await _costumerGenericRedis.DeleteListRedis("Question");
            }
            return result;
        }
    }
}
