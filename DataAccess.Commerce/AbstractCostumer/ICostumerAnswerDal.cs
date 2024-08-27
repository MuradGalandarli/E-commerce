using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerAnswerDal
    {
        public Task<Answer> AddAnswer(Answer answer);
        public Task<bool> DeleteAnswer(int id);
        public Task<Answer> GetAnswer(int id);
        public Task<List<Answer>> GetAllListAnswer();
        public Task<Answer> UpdateAnswer(Answer answer);
    }
}
