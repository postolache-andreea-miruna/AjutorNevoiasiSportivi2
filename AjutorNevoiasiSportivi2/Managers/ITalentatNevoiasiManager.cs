using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface ITalentatNevoiasiManager
    {
        List<TalentatNevoiasiModel> GetTalentatNevoiasi();
        List<GetTalentNevoiasiModel> GetNevoiasiInfo(int id);
        void Delete(int id);
        void Create(CreareNevoiasModel creareNevoiasModel);
        void Update(NevoiasUpdateModel nevoiasUpdateModel);
    }
}
