namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class ModelInsertViewModel
    {

      
        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public int? ParentModelId { get; set; }
        public string ParentName { get; set; }


        public string Name { get; set; } 
    }
}
