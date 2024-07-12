using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class EfGoodsRepository:Generic<Goods>,IGoodsDal
    {
        private readonly ApplicationContext _context;
             
        public EfGoodsRepository(ApplicationContext context):base(context)
        {

            _context = context;

        }
    }
}
