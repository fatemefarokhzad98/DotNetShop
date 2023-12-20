using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
    public partial class Province 
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; }=null!;

    }
}
