using AjutorNevoiasiSportivi2.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class DonariRepository: IDonariRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public DonariRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Donare> GetDonariDonator()
        {
            var donari = db.Donari
                .Include(x => x.Donator);
            return donari;

        }
        
        public IQueryable<Donare> GetDonariNevoias()
        {
            var donari = db.Donari
                .Include(x => x.TalentatNevoias);
            return donari;
        }

        public IQueryable<Donare> GetDonariNevoiasDonator()
        {
            var donari = db.Donari
                .Include(x => x.TalentatNevoias)
                .Include(x => x.Donator);
            return donari;
        }
        
    }
}
