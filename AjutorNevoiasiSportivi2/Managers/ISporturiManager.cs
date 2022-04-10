using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface ISporturiManager
    {
        List<SportModel> GetSporturi();
        void Delete(int id);
        void Create(CreareSportModel creareSportModel);
        void Update(SportModel sportModel);
    }
}
