using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.Product
{
    public  class BrandSurenessService: IBrandSurenessService
    { 
        private readonly IBrandRepository _bradRepository;
        public BrandSurenessService(IBrandRepository bradRepository)
        {
            _bradRepository = bradRepository;


        }

        public void EnsureBrandIsNotExist(int brandId)
        {
          var brand=  _bradRepository.GetId(brandId);
            if (brand != null)
                throw new Exception();

        }
        public void EnsureBrandIsNotExist(string brandName)
        {
            var brand = _bradRepository.GetName(brandName);
            if (brand != null)
                throw new Exception();
        }
       
        public void EnSureBrandIsExist(string brandName)
        {
            var brand=_bradRepository.GetName(brandName);
            if (brand == null)
                throw new Exception();


        }

        public void EnsureBrandIsExist(int brandId)
        {
            var brand = _bradRepository.GetId(brandId);
            if (brand == null)
                throw new Exception();
        }
    }
}
