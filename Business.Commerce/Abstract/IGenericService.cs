using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Add (T t);
        Task<T> Update (T t);
        
        Task<T> GetbyId (int id);
       
        Task<List<T>> GetList();
        public Task<bool> Delete(int id);

    }
}
