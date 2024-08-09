using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.AbstractCostumer
{
    public interface ICostumerUserDal : IGeneric<User>
    {
        public Task<bool> RemoveUser(int id);
        public Task<List<User>> getallUser();
        public Task<List<User>> TheUsersPurchaseHistory(int userId);

    }
}
