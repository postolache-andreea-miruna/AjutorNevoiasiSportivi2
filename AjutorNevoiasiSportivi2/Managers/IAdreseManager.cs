using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IAdreseManager
    {
        List<AdreseModel> GetAdrese();
        List<GetAdresaModel> GetAdreseInfo(int id);
        void Delete(int id);
        void Create(CreareAdresaModel creareAdresaModel);
        void Update(AdresaUpdateModel adresaUpdateModel);
    }
}
