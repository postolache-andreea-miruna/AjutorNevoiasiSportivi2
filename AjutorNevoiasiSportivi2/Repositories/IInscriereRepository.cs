using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IInscriereRepository
    {
        IQueryable<Inscriere> GetInscriereNevAntrCl();
        IQueryable<Inscriere> GetInscriereNev();
    }
}
