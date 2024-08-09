using Business.Commerce.Abstract;
using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class UserManager : IUserService
    {
        private readonly ICostumerUserDal _userDal;
        public UserManager(ICostumerUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<User> Add(User t)
        {
            await _userDal.Add(t);
            return t;
        }

        public async Task<bool> Delete(int id)
        {
          var isTrue = await _userDal.RemoveUser(id);
           return isTrue;
        }

        public async Task<User> GetbyId(int id)
        {
          var result = await _userDal.GetById(id);
/*
            if (result.Status)
            {
                return result;
            }*/
            return null;
        }

        public async Task<List<User>> GetList()
        {
           return await _userDal.getallUser();
        }

        public async Task<User> Update(User t)
        {
           await _userDal.Update(t);
            return t;
        }
    }
}
