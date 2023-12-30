
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string ProviceName { get; set; } = null!;
        public int ProvinceId { get; set; }

    }
}
