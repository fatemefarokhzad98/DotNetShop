namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryInPurViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public bool IsActive { get; set; }

       
    }
}
