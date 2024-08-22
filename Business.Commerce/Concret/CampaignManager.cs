using Business.Commerce.Abstract;
using DataAccess.Commerce.Abstract;
using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commerce.Concret
{
    public class CampaignManager : ICampaignService
    {
        private readonly ICampaignDal _campaingDal;
        public CampaignManager(ICampaignDal _campaingDal)
        {
            this._campaingDal = _campaingDal;
        }
        public async Task<Campaign> Add(Campaign t)
        {
            var result = await _campaingDal.AddCampaign(t);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(Campaign, bool IsSuccess)> DeleteCampaign(int id)
        {
           var result = await _campaingDal.DeleteCampaign(id);
            return result;
        }

        public async Task<Campaign> GetbyId(int id)
        {
            var result = await _campaingDal.GetByIdCampaign(id);
            return result;
        }

        public async Task<List<Campaign>> GetList()
        {
            var result = await _campaingDal.AllListCampaign();
            return result;
        }

        public async Task<Campaign> Update(Campaign t)
        {
            var result = await _campaingDal.UpdateCampaign(t);
            return result;  
        }
    }
}
