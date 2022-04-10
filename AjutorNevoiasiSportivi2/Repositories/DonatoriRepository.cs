using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public class DonatoriRepository: IDonatoriRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public DonatoriRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Donator> GetDonatoriIQueryable()
        {
            var donatori = db.Donatori;
         
            return donatori;
        }

        public void Delete(Donator donator)
        {
            db.Donatori.Remove(donator);
            db.SaveChanges();
        }

        public void Create(Donator donator)
        {
            db.Donatori.Add(donator);
            db.SaveChanges();
        }

        public void Update(Donator donator)
        {
            db.Donatori.Update(donator);
            db.SaveChanges();
        }
    }
}
