using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class BrandAppService:IBrandAppService
    {

      
        private readonly IBrandService _brandService;
        private readonly IBrandSurenessService _brandSurenessService;

        public BrandAppService(IBrandService brandService , IBrandSurenessService brandSurenessService)
        {
            _brandService = brandService;
            _brandSurenessService= brandSurenessService

        }

        public BrandDto GetBrand(int id)
        {
            throw new NotImplementedException();
        }

        public BrandDto GetBrand(string Name)
        {
            throw new NotImplementedException();
        }

        public List<BrandDto> GetBrands()
        {
            
        }

        public void RemoveBrand(int id)
        {
            throw new NotImplementedException();
        }

        public void SetBrand(int disPlayOrder, string name)
        {
            //دسترسی رو اول چک میکنیم
            _brandSurenessService.EnsureBrandIsNotExist(name);
            _brandService.SetBrand(disPlayOrder, name);
            
        }

        public void UpdateBrand(int id, int displayOrder, string name)
        {
            throw new NotImplementedException();
        }
    }
}
