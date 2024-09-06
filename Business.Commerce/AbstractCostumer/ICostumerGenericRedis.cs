using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.AbstractCostumer
{
    public interface ICostumerGenericRedis<T> where T : class
    {
        public Task<T> ReadRedis(string key);
        public Task<T> WriteRedis(string key, string json);
        public Task<bool> DeleteKeyRedis(string key);
        public Task<long> AddListRedis(string key,List<T> t);
        public Task<List<T>> GetListRedis(string key);
        public Task<bool> DeleteListRedis(string key);

    }
}
