using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
    public class AppRoleUser:IdentityUserRole<int>
    {
        public virtual AppRole Role { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
     
      


    }
}
