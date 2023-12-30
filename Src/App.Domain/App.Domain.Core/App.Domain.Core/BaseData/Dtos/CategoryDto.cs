using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }

        public string? ParentName { get; set; }
      

    }
}
