namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryInsertViewModel
    {
      
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int DisplayOrder { get; set; }
        public string ParentName { get; set; }
        public int? ParentCategoryId { get; set; }



    }
}
