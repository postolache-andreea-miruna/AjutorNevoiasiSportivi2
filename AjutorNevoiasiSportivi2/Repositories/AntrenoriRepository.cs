using AjutorNevoiasiSportivi2.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class AntrenoriRepository: IAntrenoriRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public AntrenoriRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        
        public IQueryable<Antrenor> GetAntrenoriIQueriable()
        {
            var antrenori = db.Antrenori;
            return antrenori;
        }
        public IQueryable<Antrenor> GetAntrenoriSport()
        {
            var antrenori = db.Antrenori
                .Include(x => x.Sport);
            return antrenori;
        }
        public IQueryable<Antrenor> GetAntrenoriClub()
        {
            var antrenori = db.Antrenori
                .Include(x => x.Club);
            return antrenori;
        }
        public IQueryable<Antrenor> GetAntrenoriSportClub()
        {
            var antrenori = db.Antrenori
                .Include(x => x.Sport)
                .Include(x => x.Club);
            return antrenori;
        }

        public void Delete(Antrenor antrenor)
        {
            db.Antrenori.Remove(antrenor);
            db.SaveChanges();
        }
        public void Create(Antrenor antrenor)
        {
            db.Antrenori.Add(antrenor);
            db.SaveChanges();
        }

        public void Update(Antrenor antrenor)
        {
            db.Antrenori.Update(antrenor);
            db.SaveChanges();
        }

    }
}
