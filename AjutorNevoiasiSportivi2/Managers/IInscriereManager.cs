using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IInscriereManager
    {
        List<InscriereNevoiasModel> GetInscriereByIdNevoias(int id);
        List<InscriereAntrenorModel> GetInscriereByIdAntrenor(int id);
    }
}
