using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
    public class AppUser:IdentityUser<int>
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BrithDay { get; set; }
        public DateTime RigesterDate { get; set; }
        public DateTime LastVisitDate { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }
        public virtual ICollection< AppUserRole> Roles { get; set; } = null!;
       
    }
}
