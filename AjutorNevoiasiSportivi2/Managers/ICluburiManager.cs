using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface ICluburiManager
    {
        List<CluburiModel> GetCluburi();
        List<GetCluburiModel> GetClubuiInfo(int id);
        void Delete(int id);
        void Create(GetCluburiModel getCluburiModel);
        void Update(ClubUpdateModel clubUpdateModel);
    }
}
