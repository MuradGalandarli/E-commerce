using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFUserRepository:Generic<User>,IUserDal
    {
        private readonly ApplicationContext _context;
        public EFUserRepository(ApplicationContext context):base(context)
        {
            _context = context;
        }


    }
}
