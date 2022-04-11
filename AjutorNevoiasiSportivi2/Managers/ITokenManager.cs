using AjutorNevoiasiSportivi2.Entities;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface ITokenManager
    {
        Task<string> CreateToken(User user);
    }
}
