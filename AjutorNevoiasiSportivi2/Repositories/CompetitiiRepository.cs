using AjutorNevoiasiSportivi2.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace AjutorNevoiasiSportivi2.Repositories
{
    public class CompetitiiRepository : ICompetitiiRepository
    {
        private AjutorNevoiasiSportivi2Context db;
        public CompetitiiRepository(AjutorNevoiasiSportivi2Context db)
        {
            this.db = db;
        }
        public IQueryable<Competitie> GetCompetitiiIQueryable()
        {
            var competitii = db.Competitii;
            return competitii;
        }
        public void Delete(Competitie competitie)
        {
            db.Competitii.Remove(competitie);
            db.SaveChanges();
        }
        public void Create(Competitie competitie)
        {
            db.Competitii.Add(competitie);
            db.SaveChanges();
        }
        public void Update(Competitie competitie)
        {
            db.Competitii.Update(competitie);
            db.SaveChanges();
        }
    }
}
