using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Dtos
{
    public class ProviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;


        public virtual ICollection<CityDto> Cities { get; set; } = null!;
    }
}
