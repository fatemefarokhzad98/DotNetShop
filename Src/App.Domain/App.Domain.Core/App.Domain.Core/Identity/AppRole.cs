using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Identity
{
    public class AppRole:IdentityRole<int>
    {
        public AppRole()
        {

        }
        public AppRole(string name):base(name)
        {


        }
        public AppRole(string name,string description):base(name)
        {
            description = description;
        }
        public string Description { get; set; } = null!;
    }
}
