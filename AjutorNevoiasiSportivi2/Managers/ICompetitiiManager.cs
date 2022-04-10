using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface ICompetitiiManager
    {
        List<CompetitieModel> GetCompetitii();
        List<GetCompetitieModel> GetCompetitiiInfo(int id);
        void Delete(int id);
        void Create(CreareCompModel creareCompModel);
        void Update(CompetitieUpdateModel competitieUpdateModel);
    }
}
