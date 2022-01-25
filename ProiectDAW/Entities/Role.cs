using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ProiectDAW.Entities
{
    public class Role : IdentityRole
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
