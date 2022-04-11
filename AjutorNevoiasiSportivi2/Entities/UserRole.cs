using Microsoft.AspNetCore.Identity;

namespace AjutorNevoiasiSportivi2.Entities
{
    public class UserRole:IdentityUserRole<string>
    {
        public UserRole() : base() { }
        public override string UserId { get; set; }
        public virtual User User { get; set; }
        public override string RoleId { get; set; }
        public virtual Role Role { get; set; }
        
    }


    /*    public class AspNetUserRoles : IdentityUserRole<string>
        {
            public AspNetUserRoles() : base()
            {
            }
            public override string UserId { get; set; }
            public virtual AspNetUser User { get; set; }
            public override string RoleId { get; set; }
            public virtual AspNetRoles Role { get; set; }*/
}

