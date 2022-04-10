using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IDonatoriManager
    {
        List<DonatorModel> GetDonatori();
        List<GetDonatorModel> GetDonatorInfo(int id);
        void Delete(int id);
        void Create(GetDonatorModel getDonatorModel);
        void Update(DonatorUpdateModel donatorUpdateModel);
    }
}
