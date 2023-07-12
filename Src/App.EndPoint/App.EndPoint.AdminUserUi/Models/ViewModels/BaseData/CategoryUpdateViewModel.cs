using App.Domain.Core.BaseData.Dtos;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryUpdateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ParentName { get; set; }

    }
}
