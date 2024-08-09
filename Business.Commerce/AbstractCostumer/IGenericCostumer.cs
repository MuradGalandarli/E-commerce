using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface IGenericCostumer<T> where T : class
    {
        public Task<List<T>> GetAllList();
    }
}
