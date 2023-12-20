using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
     public class AppRole:IdentityRole<int>
    {
        public AppRole()
        {

        }
        public AppRole(string name) : base(name)
        {


        }
        public AppRole(string name, string description) : base(name)
        {
            Description = description;
        }
        public string Description { get; set; } = null!;
        public  virtual ICollection<AppRoleUser> Users { get; set; }= null!;
    }
}
