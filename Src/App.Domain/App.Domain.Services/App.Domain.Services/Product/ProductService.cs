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
    internal class ProductService : IProductService
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

        public bool Exist(int Id)
        {
            return _brandRepository.Exist(Id);
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
    }
}
