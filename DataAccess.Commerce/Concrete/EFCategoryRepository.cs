using DataAccess.Commerce.Abstract;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<EFCategoryRepository> _logger;
        public EFCategoryRepository(ApplicationContext _context
            , ILogger<EFCategoryRepository> _logger) :base(_context,_logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

        public async Task<List<Category>> getallCategory()
        {
            try
            {
                var result = await _context.Categories.Where(x => x.CategoryStatus == true).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
            return null;
        }

     
            public async Task<bool> RemoveCategory(int id)
            {
            try
            {
                var result = await _context.Categories.FindAsync(id);
                if (result != null)
                {
                    result.CategoryStatus = false;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
                return false;
            }
    }
}
