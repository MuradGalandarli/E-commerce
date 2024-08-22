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
    public class OtherCapaignManager : IOtherCampaignService
    {
        private readonly IOtherCampaignDal _otherCampaignDal;
        public OtherCapaignManager(IOtherCampaignDal _otherCampaignDal)
        {
            this._otherCampaignDal = _otherCampaignDal;
        }


        public async Task<OtherCampaign> Add(OtherCampaign t)
        {
            var result = await _otherCampaignDal.AddOtherCampaign(t);
            return result;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Task<OtherCampaign> GetbyId(int id)
        {
            var result = _otherCampaignDal.GetByIdOtherCampaign(id);
            return result;
        }

        public async Task<List<OtherCampaign>> GetList()
        {
            var result = await _otherCampaignDal.AllListOtherCampaign();
            return result;
        }

        public async Task<OtherCampaign> Update(OtherCampaign t)
        {
           var result = await _otherCampaignDal.UpdateOtherCampaign(t);
            return result;
        }

       public async Task<(OtherCampaign, bool IsSuccess)> RemoveOtherCampaign(int id)
        {
            var result = await _otherCampaignDal.DeleteOtherCampaign(id);
            return result;
        }

    }
}
