using Business.Commerce.Abstract;
using DataTransferObject.EntityDto;
using EntityCommerce;
using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerQuestionService:IGenericService<QuestionDto>
    {
        public Task<Enums.likeEnum> QuestionLikeOrDisLike(QuestionLike questionLike);

    }
}
