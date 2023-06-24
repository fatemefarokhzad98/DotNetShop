using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IBrandRepository _brandRepository;

        public ProductService(IBrandRepository brandRepository )
        {
            _brandRepository = brandRepository;

        }

        public void CreateBrand(Brand brand)
        {
            _brandRepository.CreateBrand(brand);
        }

        public Brand? GetId(int Id)
        {
            return _brandRepository.GetId(Id);
        }

        public List<Brand> GetAllBrnds()
        {
            return _brandRepository.GetAllBrnds();
        }

        public void RemoveBrand(int Id)
        {
             _brandRepository.RemoveBrand(Id);
        }

        public void UpdateBrand(Brand brand)
        {
            _brandRepository.UpdateBrand(brand);
            
        }
        public Brand? GetName(string name)
        {
          return  _brandRepository.GetName(name);
        }
    }
}
