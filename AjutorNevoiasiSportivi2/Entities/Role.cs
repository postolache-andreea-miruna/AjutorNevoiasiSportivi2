using Microsoft.AspNetCore.Identity;

namespace AjutorNevoiasiSportivi2.Entities
{
    public class Role:IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
