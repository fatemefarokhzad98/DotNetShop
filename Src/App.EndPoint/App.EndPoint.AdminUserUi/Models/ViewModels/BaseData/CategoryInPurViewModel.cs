namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryInPurViewModel
    {

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
    }
}
