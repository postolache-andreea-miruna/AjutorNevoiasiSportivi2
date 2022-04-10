using AjutorNevoiasiSportivi2.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class InscriereRepository: IInscriereRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public InscriereRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Inscriere> GetInscriereNevAntrCl()
        {
            var inscrieri = db.Inscrieri
                .Include(x => x.Antrenor)
                .Include(x => x.TalentatNevoias)
                .Include(x => x.Antrenor.Club);
            return inscrieri;
        }
        public IQueryable<Inscriere> GetInscriereNev()
        {
            var inscrieri = db.Inscrieri
                .Include(x => x.TalentatNevoias);
            return inscrieri;
        }
        
    }
}
