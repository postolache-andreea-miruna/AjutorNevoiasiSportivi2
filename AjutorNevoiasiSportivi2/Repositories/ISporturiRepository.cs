using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface ISporturiRepository
    {
        IQueryable<Sport> GetSporturiIQueryable();
        void Delete(Sport sport);
        void Create(Sport sport);
        void Update(Sport sport);
    }
}
