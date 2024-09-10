using AutoMapper;
using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using DataTransferObject.EntityDto;
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
        private readonly ICostumerGenericRedis<AnswerDto> _costumerGenericRedis;
        private readonly IMapper _mapper;
        public CostumerAnswerManager(ICostumerAnswerDal _answerDal
            , ICostumerGenericRedis<AnswerDto> costumerGenericRedis
            , IMapper _mapper)
        {
            this._answerDal = _answerDal;
            _costumerGenericRedis = costumerGenericRedis;  
            this._mapper = _mapper; 
        }

        public async Task<AnswerDto> Add(AnswerDto t)
        {
            var answerMap = _mapper.Map<Answer>(t);
            var result = await _answerDal.AddAnswer(answerMap);
            if (result != null)
            {
                var writeRedis =  await _costumerGenericRedis.AddListRedis("Answer", new List<AnswerDto> { t });
            }
            return t;
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

        public async Task<AnswerDto> GetbyId(int id)
        {
          
           var result = await _answerDal.GetAnswer(id);
            var answerDto = _mapper.Map<AnswerDto>(result);
            return answerDto;
        }

        public async Task<List<AnswerDto>> GetList()
        {
            var redisData = await _costumerGenericRedis.GetListRedis("Answer");
            if(redisData != null && redisData.Count > 0)
            {
                return redisData;
            }
            var result = await _answerDal.GetAllListAnswer();
            var answerDto = _mapper.Map<AnswerDto>(result);
            if (result != null && result.Count > 0)
            {
                await _costumerGenericRedis.AddListRedis("Answer",new List<AnswerDto> { answerDto });
            }
            return new List<AnswerDto> { answerDto };
        }
        public async Task<AnswerDto> Update(AnswerDto t)
        {
            var answerDto = _mapper.Map<Answer>(t);
            var result = await _answerDal.UpdateAnswer(answerDto);
            if (result != null)
            {
                await _costumerGenericRedis.DeleteListRedis("Answer");
            }
                return t;
        }

      
    }
}
