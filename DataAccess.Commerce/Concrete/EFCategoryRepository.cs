using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EFCategoryRepository: Generic<Category>,ICategoryDal
    {
        private readonly ApplicationContext _context;
        public EFCategoryRepository(ApplicationContext _context):base(_context)
        {
            this._context = _context;
        }
    }
}
