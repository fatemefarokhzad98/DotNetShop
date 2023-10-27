using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Dtos
{
    public class RolesDto
    {
        

        public int RoleId { get; set; }

        public string RoleName { get; set; } = null!;
      
        public string RoleDescription { get; set; } = null!;

        public int CountUser { get; set; }
    }
}
