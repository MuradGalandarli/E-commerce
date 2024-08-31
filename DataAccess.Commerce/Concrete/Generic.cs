using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Concrete
{
    public class Generic<T> : IGeneric<T> where T : class
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<Generic<T>> _logger;
        public Generic(ApplicationContext context,
            ILogger<Generic<T>> _logger)
        {
            _context = context;
            this._logger = _logger;
        }

        public async Task<T> Add(T t)
        {
            try
            {
                var result = await _context.Set<T>().AddAsync(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;

        }

        public async Task Delete(int id)
        {
            try
            {
                var result = _context.Remove(id);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());    
            }        
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                var result = await _context.Set<T>().ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                var result = await _context.Set<T>().FindAsync(id);
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

        public async Task<T> Update(T t)
        {
            try
            {
                _context.Set<T>().Update(t);
                await _context.SaveChangesAsync();
                return t;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }
    }
}
