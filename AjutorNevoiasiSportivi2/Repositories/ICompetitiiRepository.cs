using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface ICompetitiiRepository
    {
        IQueryable<Competitie> GetCompetitiiIQueryable();
        void Delete(Competitie competitie);
        void Create(Competitie competitie);
        void Update(Competitie competitie);
    }
}
