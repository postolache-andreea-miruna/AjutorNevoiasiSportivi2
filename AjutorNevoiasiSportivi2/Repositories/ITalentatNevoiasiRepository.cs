using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface ITalentatNevoiasiRepository
    {
        IQueryable<TalentatNevoias> GetNevoiasiIQueryable();
        void Delete(TalentatNevoias talentatNevoias);
        void Create(TalentatNevoias talentatNevoias);
        void Update(TalentatNevoias talentatNevoias);
    }

}
