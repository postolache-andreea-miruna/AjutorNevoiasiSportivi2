using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class ProbaRepository: IProbaRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public ProbaRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Proba> GetProbeIQueryable()
        {
            var probe = db.Probe;
            return probe;
        }

        public void Delete(Proba proba)
        {
            db.Probe.Remove(proba);
            db.SaveChanges();
        }

        public void Create(Proba proba)
        {
            db.Probe.Add(proba);
            db.SaveChanges();
        }
        public void Update(Proba proba)
        {
            db.Probe.Update(proba);
            db.SaveChanges();

        }
    }
}
