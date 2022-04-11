using Microsoft.AspNetCore.Identity;

namespace AjutorNevoiasiSportivi2.Entities
{
    public class User:IdentityUser
    {
        public  virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
