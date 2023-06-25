namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class BrandOutPutViewModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public DateTime CreationDate { get; set; }
        public int DisPlayOrder { get; set; }
        public  bool IsDeleted { get; set; }


    }
}
