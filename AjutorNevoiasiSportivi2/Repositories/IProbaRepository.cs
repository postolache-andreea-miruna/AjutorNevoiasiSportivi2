using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IProbaRepository
    {
        IQueryable<Proba> GetProbeIQueryable();
        void Delete(Proba proba);
        void Create(Proba proba);
        void Update(Proba proba);
    }
}
