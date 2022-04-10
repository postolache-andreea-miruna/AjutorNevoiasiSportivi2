using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IAntrenoriManager
    {
        List<AntrenorModel> GetAntrenori();
        List<GetAntrenorModel> GetAntrenorById(int id);
        List<ClubAntrenorModel> GetAntrenorByIdClub(int id);
        List<SportAntrenorModel> GetAntrenorByIdSport(int id);
        void Delete(int id);
        void Create(CreareAntrenorModel creareAntrenorModel);
        void Update(AntrenorUpdateModel antrenorUpdateModel);
    }
}
