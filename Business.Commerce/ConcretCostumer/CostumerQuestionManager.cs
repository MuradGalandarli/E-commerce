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
    public class CostumerQuestionManager : ICostumerQuestionService
    {
        private readonly ICostumerQuestionDal _costumerQuestionDal;
        public CostumerQuestionManager(ICostumerQuestionDal _costumerQuestionDal)
        {
            this._costumerQuestionDal = _costumerQuestionDal;
        }

        public async Task<Question> Add(Question t)
        {
            var result = await _costumerQuestionDal.AddQuestion(t);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
          var result = await  _costumerQuestionDal.DeleteQuestion(id);
            return result;
        }

        public Task<Question> GetbyId(int id)
        {
            var result = _costumerQuestionDal.GetQuestion(id);
            return result;
        }

        public async Task<List<Question>> GetList()
        {
           var result = await _costumerQuestionDal.GetAllListQuestion();
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
            return result;
        }
    }
}
