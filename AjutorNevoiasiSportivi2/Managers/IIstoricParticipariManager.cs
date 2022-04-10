using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IIstoricParticipariManager
    {
        List<IstoricModel> GetIstoriceSpCompProba();
        List<IstoricIstModel> GetIstoricByIdSp(int id);
        List<IstoricBestOfModel> GetBestOfcByIdSp(int id);
    }
}
