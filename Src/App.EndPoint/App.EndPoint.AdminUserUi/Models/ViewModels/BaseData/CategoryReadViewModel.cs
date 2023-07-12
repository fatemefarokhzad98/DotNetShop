namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryReadViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ParentName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }


    }
}
