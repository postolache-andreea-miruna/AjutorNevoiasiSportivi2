using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class CluburiRepository: ICluburiRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public CluburiRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Club> GetCluburiIQueryable()
        {
            var cluburi = db.Cluburi;
            return cluburi;
        }
        public void Delete(Club club)
        {
            db.Cluburi.Remove(club);
            db.SaveChanges();
        }
        public void Create(Club club)
        {
            db.Cluburi.Add(club);
            db.SaveChanges();
        }
        public void Update(Club club)
        {
            db.Cluburi.Update(club);
            db.SaveChanges();
        }
    }
}
