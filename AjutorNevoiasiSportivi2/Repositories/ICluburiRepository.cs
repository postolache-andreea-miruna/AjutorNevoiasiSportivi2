using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface ICluburiRepository
    {
        IQueryable<Club> GetCluburiIQueryable();
        void Delete(Club club);
        void Create(Club club);
        void Update(Club club);
    }
}
