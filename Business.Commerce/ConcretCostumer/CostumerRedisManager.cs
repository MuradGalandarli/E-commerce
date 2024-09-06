using Business.Commerce.AbstractCostumer;
using EntityCommerce;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.ConcretCostumer
{
    public class CostumerRedisManager<T> : ICostumerGenericRedis<T> where T : class
    {
    private readonly IConnectionMultiplexer _connectionMultiplexer;
    private readonly IDatabase _database;
        public CostumerRedisManager(IConnectionMultiplexer _connectionMultiplexer)
        {
            this._connectionMultiplexer = _connectionMultiplexer;
            _database = _connectionMultiplexer.GetDatabase();
        }   

        public async Task<long> AddListRedis(string key,List<T> t)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            var redisValues = t.Select(x => (RedisValue)JsonConvert.SerializeObject(x,settings)).ToArray();

            var result = await _database.ListRightPushAsync(key, redisValues);

            return result;
        }

        public async Task<bool> DeleteKeyRedis(string key)
        {
            var result = await _database.StringGetDeleteAsync(key);
            if (!result.IsNullOrEmpty)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteListRedis(string key)
        {
            await _database.KeyDeleteAsync(key);
            return true;
        }

        public async Task<List<T>> GetListRedis(string key)
        {
            var redisValues = await _database.ListRangeAsync(key, 0, -1);
            var list = redisValues
                .Select(value => JsonConvert.DeserializeObject<T>(value.ToString() ))
                .ToList();
            return list;

        }
     
        public async Task<T> ReadRedis(string key)
        {
            var result = await _database.StringGetAsync(key);
            if (!result.IsNullOrEmpty)
            {
                return JsonConvert.DeserializeObject<T>(result);
            }
            return default(T);

        }

        public async Task<T> WriteRedis(string key, string json)
        {
            var result = _database.StringSetAsync(key, json);
            return default(T);
        }

         

    }
}
