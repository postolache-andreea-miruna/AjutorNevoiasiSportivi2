using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IAdreseRepository
    {
        IQueryable<Adresa> GetAdreseNevIQueryable();
        IQueryable<Adresa> GetAdreseIQueryable();
        void Delete(Adresa adresa);
        void Create(Adresa adresa);
        void Update(Adresa adresa);
    }
}
