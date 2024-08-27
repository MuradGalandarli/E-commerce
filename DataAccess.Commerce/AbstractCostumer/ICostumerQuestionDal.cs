using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerQuestionDal
    {
        public Task<Question> AddQuestion(Question question);
        public Task<bool> DeleteQuestion(int id);
        public Task<Question> GetQuestion(int id);
        public Task<List<Question>> GetAllListQuestion();
        public Task<Question> UpdateQuestion(Question question);
    }
}
