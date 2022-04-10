using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IDonariRepository
    {
        IQueryable<Donare> GetDonariDonator();
        IQueryable<Donare> GetDonariNevoias();
        IQueryable<Donare> GetDonariNevoiasDonator();
    }
}
