using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFQuestionRepositoryCostumer : ICostumerQuestionDal
    {private readonly ApplicationContext _context;
        public EFQuestionRepositoryCostumer(ApplicationContext _context)
        {
            this._context = _context;
        }
        public async Task<Question> AddQuestion(Question question)
        {
            var checkUser = await _context.Users.AnyAsync(x => x.UserId == question.UserId && x.Status == true);
           
            if (checkUser)
            {
                _context.Questions.Add(question);
                await _context.SaveChangesAsync();
                return question;
            }
            return null;
        }

        public async Task<bool> DeleteQuestion(int id)
        {

            var result = await this.GetQuestion(id);
            if (result != null)
            {
                result.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Question>> GetAllListQuestion()
        {
            var result = await _context.Questions.Where(x => x.Status == true).ToListAsync();
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Question> GetQuestion(int id)
        {
            var result = await _context.Questions.FirstOrDefaultAsync(x => x.QuestionId == id && x.Status == true);
            if (result != null)
            {
                return result;
            }
            return null;
        }

        public async Task<Question> UpdateQuestion(Question question)
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
            return null;
        }
    }
}
