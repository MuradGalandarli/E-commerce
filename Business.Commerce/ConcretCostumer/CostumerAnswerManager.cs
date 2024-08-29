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
        public CostumerAnswerManager(ICostumerAnswerDal _answerDal)
        {
            this._answerDal = _answerDal;
        }

        public async Task<Answer> Add(Answer t)
        {
            var result = await _answerDal.AddAnswer(t);
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
            return result;
        }

        public async Task<Answer> GetbyId(int id)
        {
           var result = await _answerDal.GetAnswer(id);
            return result;
        }

        public async Task<List<Answer>> GetList()
        {
            var result = await _answerDal.GetAllListAnswer();
            return result;
        }
        public async Task<Answer> Update(Answer t)
        {
                var result = await _answerDal.UpdateAnswer(t);
                return result;
        }
    }
}
