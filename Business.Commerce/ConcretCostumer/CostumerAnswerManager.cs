using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerAnswerManager : ICostumerAnswerService
    {  
        private readonly ICostumerAnswerDal _answerDal;
        private readonly ICostumerGenericRedis<Answer> _costumerGenericRedis;
        public CostumerAnswerManager(ICostumerAnswerDal _answerDal
            , ICostumerGenericRedis<Answer> costumerGenericRedis)
        {
            this._answerDal = _answerDal;
            _costumerGenericRedis = costumerGenericRedis;   
        }

        public async Task<Answer> Add(Answer t)
        {
            var result = await _answerDal.AddAnswer(t);
            if (result != null)
            {
                var writeRedis =  await _costumerGenericRedis.AddListRedis("Answer", new List<Answer> { result });
            }
            return result;
        }

        public Task<Enums.likeEnum> AnswerLikeOrDisLike(AnswerLike answerLike)
        {
            var result = _answerDal.AnswerLikeOrDisLike(answerLike);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await _answerDal.DeleteAnswer(id);
            if(result)
            {
                await _costumerGenericRedis.DeleteListRedis("Answer");
            }
            return result;
        }

        public async Task<Answer> GetbyId(int id)
        {
           var result = await _answerDal.GetAnswer(id);
            return result;
        }

        public async Task<List<Answer>> GetList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("Answer");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _answerDal.GetAllListAnswer();
            if (result != null && result.Count > 0)
            {
                await _costumerGenericRedis.AddListRedis("Answer", result);
            }
            return result;
        }
        public async Task<Answer> Update(Answer t)
        {
            var result = await _answerDal.UpdateAnswer(t);
            if (result != null)
            {
                await _costumerGenericRedis.DeleteListRedis("Answer");
            }
                return result;
        }
    }
}
