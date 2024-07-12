using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface IGeneric<T> where T : class
    {
       Task<T> Add(T t);
        Task<T> Update(T t);
        Task Delete(int id);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
    }
}
