using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
    public partial class City
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public int ProvinceId { get; set; }

       public virtual Province Province { get; set; }=null!;


    }
}
