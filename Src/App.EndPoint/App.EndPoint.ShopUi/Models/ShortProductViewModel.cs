using App.Domain.Core.BaseData.Dtos;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Models
{
    public class ShortProductViewModel
    {

        public int Id { get; set; }
      
        public string Name { get; set; }
         
        public string BrandName { get; set; }

           public decimal Price { get; set; }
    
        public string Image { get; set; }
        public List<int> Colors{ get; set; }




    }
}
