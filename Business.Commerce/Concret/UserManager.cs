using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class UserManager : IGenericService<User>
    {
        private readonly IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<User> Add(User t)
        {
            await _userDal.Add(t);
            return t;
        }

        public async Task Delete(int id)
        {
           await _userDal.Delete(id);
        }

        public async Task<User> GetbyId(int id)
        {
          return await _userDal.GetById(id);
        }

        public async Task<List<User>> GetList()
        {
           return await _userDal.GetAll();
        }

        public async Task<User> Update(User t)
        {
           await _userDal.Update(t);
            return t;
        }
    }
}
