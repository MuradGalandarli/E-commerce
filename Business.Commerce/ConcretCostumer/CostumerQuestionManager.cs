using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
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
        private readonly ICostumerGenericRedis<QuestionDto> _costumerGenericRedis;
        private readonly IMapper _mapper;
        public CostumerQuestionManager(ICostumerQuestionDal _costumerQuestionDal
            , ICostumerGenericRedis<QuestionDto> _costumerGenericRedis
            , IMapper _mapper)
        {
            this._costumerQuestionDal = _costumerQuestionDal;
            this._costumerGenericRedis = _costumerGenericRedis;
            this._mapper = _mapper;
        }

        public async Task<QuestionDto> Add(QuestionDto t)
        {
            var questionMap = _mapper.Map<Question>(t);
            var result = await _costumerQuestionDal.AddQuestion(questionMap);
            if (result != null)
            {
                var mapQuestion = _mapper.Map<QuestionDto>(result);
                await _costumerGenericRedis.AddListRedis("Question", new List<QuestionDto> { mapQuestion });
                return mapQuestion;
            }

            return null;
        }

        public async Task<bool> Delete(int id)
        {
            var IsSuccess = await _costumerQuestionDal.DeleteQuestion(id);
            if (IsSuccess)
            {
                await _costumerGenericRedis.DeleteListRedis("Question");
            }

            return IsSuccess;
        }

        public async Task<QuestionDto> GetbyId(int id)
        {
            var result = _costumerQuestionDal.GetQuestion(id);
            if (result != null)
            { 
                var mapQuestion = _mapper.Map<QuestionDto>(result);
                return mapQuestion;
            }
            return null;
        }

        public async Task<List<QuestionDto>> GetList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("Question");
            if (redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _costumerQuestionDal.GetAllListQuestion();
            if (result != null)
            {
                var mapQuestion = _mapper.Map<List<QuestionDto>>(result);
                await _costumerGenericRedis.AddListRedis("Question", mapQuestion);
                return mapQuestion;
            }
            return null;
        }

        public async Task<Enums.likeEnum> QuestionLikeOrDisLike(QuestionLike questionLike)
        {
            var result = await _costumerQuestionDal.QuestionLikeOrDisLike(questionLike);
            return result;
        }

        public async Task<QuestionDto> Update(QuestionDto t)
        { 
            var questionDto = _mapper.Map<Question>(t);
            var result = await _costumerQuestionDal.UpdateQuestion(questionDto);
            if (result != null)
            {
                var Dtoquestion = _mapper.Map<QuestionDto>(t);
                await _costumerGenericRedis.DeleteListRedis("Question");
                return Dtoquestion;
            }
            return null;
        }
    }
}
