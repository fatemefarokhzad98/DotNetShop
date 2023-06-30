namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class ModelOutPutViewModel
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int? ParentModelId { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
    }
}
