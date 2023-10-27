using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
    public partial class Cities
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int ProviceId { get; set; }
        public virtual Provices Provice { get; set; }= null!;
    }
}
