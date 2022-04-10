using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IAntrenoriRepository
    {
        IQueryable<Antrenor> GetAntrenoriSport();
        IQueryable<Antrenor> GetAntrenoriSportClub();
        IQueryable<Antrenor> GetAntrenoriClub();
        IQueryable<Antrenor> GetAntrenoriIQueriable();
        void Delete(Antrenor antrenor);
        void Create(Antrenor antrenor);
        void Update(Antrenor antrenor);
    }
}
