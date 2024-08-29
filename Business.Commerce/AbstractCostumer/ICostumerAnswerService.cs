using Business.Commerce.Abstract;
using EntityCommerce;
using EntityCommerce.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerAnswerService:IGenericService<Answer>
    {
        public Task<Enums.likeEnum> AnswerLikeOrDisLike(AnswerLike answerLike);

    }
}
