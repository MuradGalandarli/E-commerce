using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerUserService
    {
        public Task<List<User>> TheUsersPurchaseHistory(int userId);
    }
}
