using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IProbaManager
    {
        List<ProbaModel> GetProbe();
        void Delete(int id);
        void Create(CreareProbModel creareProbModel);
        void Update(ProbaUpdateModel probaUpdateModel);
    }
}
