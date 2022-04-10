using AjutorNevoiasiSportivi2.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class IstoricParticipariRepository: IIstoricParticipariRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public IstoricParticipariRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<IstoricParticipare> GetIstoriceIQueryable()
        {
            var istorice = db.IstoricParticipari
                .Include(i => i.Proba)
                .Include(i => i.Competitie)
                .Include(i => i.TalentatNevoias);
            return istorice;
        }

        public IQueryable<IstoricParticipare> GetIstoricPrComp()
        {
            var istorice = db.IstoricParticipari
                .Include(i => i.Proba)
                .Include(i => i.Competitie);
            return istorice;
        }
    }
}
