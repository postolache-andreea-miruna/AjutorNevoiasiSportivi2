using AjutorNevoiasiSportivi2.Entities;
using Microsoft.EntityFrameworkCore;


namespace AjutorNevoiasiSportivi2.Repositories
{
    public class AdreseRepository: IAdreseRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public AdreseRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Adresa> GetAdreseNevIQueryable()
        {
            var adrese = db.Adrese
                .Include(x => x.TalentatNevoias);
            return adrese;
        }
        public IQueryable<Adresa> GetAdreseIQueryable()
        {
            var adrese = db.Adrese;
            return adrese;
        }

        public void Delete(Adresa adresa)
        {
            db.Adrese.Remove(adresa);
            db.SaveChanges();
        }
        public void Create(Adresa adresa)
        {
            db.Adrese.Add(adresa);
            db.SaveChanges();
        }
        public void Update(Adresa adresa)
        {
            db.Adrese.Update(adresa);
            db.SaveChanges();
        }
    }
}
