using App.Domain.Core.Product.Contracts.AppServices;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.Product
{
    public class ProductAppService : IProductAppService
    {
        public ProductAppService(IProductAppService productAppService)
        {
            _ProductAppService = productAppService;

        }

        private readonly IProductAppService _ProductAppService;

        public void CreateBrand(Brand brand)
        {
            _ProductAppService.CreateBrand(brand);
        }

        public bool Exist(int Id)
        {
            return _ProductAppService.Exist(Id);
        }

        public List<Brand> GetAllBrnds()
        {
          return  _ProductAppService.GetAllBrnds();
        }

        public void RemoveBrand(int Id)
        {
            _ProductAppService.RemoveBrand(Id);
        }

        public void UpdateBrand(Brand brand)
        {
            _ProductAppService.UpdateBrand(brand);
        }
    }
}
