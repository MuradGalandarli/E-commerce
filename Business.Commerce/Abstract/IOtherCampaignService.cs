using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Abstract
{
    public interface IOtherCampaignService:IGenericService<OtherCampaign>
    {
        public Task<(OtherCampaign, bool IsSuccess)> RemoveOtherCampaign(int id);

    }
}
