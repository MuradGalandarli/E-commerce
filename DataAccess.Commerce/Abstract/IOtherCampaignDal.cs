using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Commerce.Abstract
{
    public interface IOtherCampaignDal
    {
        public Task<OtherCampaign> AddOtherCampaign(OtherCampaign otherCampaign);
        public Task<(OtherCampaign, bool IsSuccess)> DeleteOtherCampaign(int id);
        public Task<List<OtherCampaign>> AllListOtherCampaign();
        public Task<OtherCampaign> GetByIdOtherCampaign(int id);
        public Task<OtherCampaign> UpdateOtherCampaign(OtherCampaign otherCampaign);
    }
}
