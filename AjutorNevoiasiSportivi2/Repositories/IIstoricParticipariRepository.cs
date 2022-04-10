using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Repositories
{
    public interface IIstoricParticipariRepository
    {
        IQueryable<IstoricParticipare> GetIstoriceIQueryable();
        IQueryable<IstoricParticipare> GetIstoricPrComp();
    }
}
