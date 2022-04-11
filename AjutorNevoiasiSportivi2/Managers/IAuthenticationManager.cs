using AjutorNevoiasiSportivi2.Models;

namespace AjutorNevoiasiSportivi2.Managers
{
    public interface IAuthenticationManager
    {
        Task Signup(SignupUserModel signupUserModel);
        Task<TokenModel> Login(LoginUserModel loginUserModel);
    }
}
