using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class TalentatNevoiasiRepository: ITalentatNevoiasiRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public TalentatNevoiasiRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<TalentatNevoias> GetNevoiasiIQueryable()
        {
            var nevoiasi = db.TalentatNevoiasi;
            return nevoiasi;
        }
        public void Delete(TalentatNevoias talentatNevoias)
        {
            db.TalentatNevoiasi.Remove(talentatNevoias);
            db.SaveChanges();
        }

        public void Create(TalentatNevoias talentatNevoias)
        {
            db.TalentatNevoiasi.Add(talentatNevoias);
            db.SaveChanges();
        }
        public void Update(TalentatNevoias talentatNevoias)
        {
            db.TalentatNevoiasi.Update(talentatNevoias);
            db.SaveChanges();
        }
    }
}
