using Business.Commerce.AbstractCostumer;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerUserManager : ICostumerUserService
    {
        private readonly ICostumerUserDal _costumerUserDal;
        public CostumerUserManager(ICostumerUserDal _costumerUserDal)
        {
            this._costumerUserDal = _costumerUserDal;
        }
        public async Task<List<User>> TheUsersPurchaseHistory(int userId)
        {
            var result = await _costumerUserDal.TheUsersPurchaseHistory(userId);
            return result;
        }
    }
}
