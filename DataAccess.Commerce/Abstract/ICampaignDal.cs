using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface ICampaignDal
    {
        public Task<Campaign> AddCampaign (Campaign campaign);
        public Task<(Campaign, bool IsSuccess)> DeleteCampaign(int id);
        public Task<List<Campaign>> AllListCampaign();
        public Task<Campaign> GetByIdCampaign(int id);
        public Task<Campaign> UpdateCampaign(Campaign campaing);
    }
}
