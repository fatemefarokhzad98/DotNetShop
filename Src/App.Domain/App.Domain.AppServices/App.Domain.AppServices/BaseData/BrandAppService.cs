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
            _brandSurenessService = brandSurenessService;

        }

        public BrandDto GetBrand(int id)
        {
            return _brandService.GetBrand(id);
        }

        public BrandDto GetBrand(string name)
        {
           
              return  _brandService.GetBrand(name);
        }

        public List<BrandDto> GetBrands()
        {
            return _brandService.GetBrands();
            
        }

        public void RemoveBrand(int id)
        {
            //دسترس چک شود
            _brandSurenessService.EnsureBrandIsExist(id);
            _brandService.RemoveBrand(id);
        }

        public void SetBrand(int disPlayOrder, string name)
        {
            //دسترسی رو اول چک میکنیم
            _brandSurenessService.EnsureBrandIsNotExist(name);
            _brandService.SetBrand(disPlayOrder, name);
            
        }

        public void UpdateBrand(int id, int displayOrder, string name)
        {
            //دسترسی رو اول چک میکنیم
            _brandSurenessService.EnsureBrandIsExist(id);


            _brandService.UpdateBrand(id, displayOrder, name);
        }
    }
}
