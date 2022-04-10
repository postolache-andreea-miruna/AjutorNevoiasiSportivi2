using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class SporturiRepository: ISporturiRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public SporturiRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }

        public IQueryable<Sport> GetSporturiIQueryable()
        {
            var sporturi = db.Sporturi;
            return sporturi;
        }
        public void Delete(Sport sport)
        {
            db.Sporturi.Remove(sport);
            db.SaveChanges();
        }
        public void Create(Sport sport)
        {
            db.Sporturi.Add(sport);
            db.SaveChanges();
        }
        public void Update(Sport sport)
        {
            db.Sporturi.Update(sport);
            db.SaveChanges();
        }
    }
}
