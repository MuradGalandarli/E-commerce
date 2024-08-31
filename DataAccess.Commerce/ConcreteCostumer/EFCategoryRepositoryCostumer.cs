using DataAccess.Commerce.AbstractCostumer;
using EntityCommerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.ConcreteCostumer
{
    public class EFCategoryRepositoryCostumer : ICostumerCategoryDal
    {
        private readonly ApplicationContext _context;
        private readonly ILogger<EFCategoryRepositoryCostumer> _logger;
        public EFCategoryRepositoryCostumer(ApplicationContext _context
            , ILogger<EFCategoryRepositoryCostumer> _logger)
        {
            this._context = _context;
            this._logger = _logger;
        }

     
public async Task<List<Category>> getAllList()
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
  
    }
}
