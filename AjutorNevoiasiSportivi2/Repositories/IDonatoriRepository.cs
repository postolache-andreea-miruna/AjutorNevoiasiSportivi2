using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IDonatoriRepository
    {
        IQueryable<Donator> GetDonatoriIQueryable();
        void Delete(Donator donator);
        void Create(Donator donator);
        void Update(Donator donator);
    }
}
