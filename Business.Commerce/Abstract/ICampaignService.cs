using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface ICampaignService:IGenericService<Campaign>
    {
        public Task<(Campaign, bool IsSuccess)> DeleteCampaign(int id);

    }
}
