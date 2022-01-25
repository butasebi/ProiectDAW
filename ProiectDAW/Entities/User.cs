using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectDAW.Entities
{
    public class User : IdentityUser
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
