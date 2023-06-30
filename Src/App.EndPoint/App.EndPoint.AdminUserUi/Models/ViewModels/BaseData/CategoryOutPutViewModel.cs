namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryOutPutViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } 

        public int? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }

        public int DisplayOrder { get; set; }
        public bool IsDeleted { get; set; }
    }
}
