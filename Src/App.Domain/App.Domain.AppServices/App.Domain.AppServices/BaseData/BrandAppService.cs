using App.Domain.Core.BaseData.Contracts.AppServices;

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
        private readonly ISurenessService _brandSurenessService;

        public BrandAppService(IBrandService brandService , ISurenessService brandSurenessService)
        {
            _brandService = brandService;
            _brandSurenessService = brandSurenessService;

        }

        public async Task< BrandDto> GetBrand(int id)
        {
            return await _brandService.GetBrand(id);
        }

        public async Task < BrandDto> GetBrand(string name)
        {
           
              return await _brandService.GetBrand(name);
        }

        public async Task< List<BrandDto>> GetBrands()
        { 
            return await _brandService.GetBrands();
            
        }

        public async Task RemoveBrand(int id)
        {
            //دسترس چک شود
           await _brandSurenessService.EnsureModelIsExist(id);
           await _brandService.RemoveBrand(id);
        }

        public async Task SetBrand(int disPlayOrder, string name)
        {
            //دسترسی رو اول چک میکنیم
          await  _brandSurenessService.EnsureModelIsNotExist(name);
          await  _brandService.SetBrand(disPlayOrder, name);
            
        }

        public async Task UpdateBrand(int id, int displayOrder, string name)
        {
            //دسترسی رو اول چک میکنیم
           await _brandSurenessService.EnsureModelIsExist(id);


          await  _brandService.UpdateBrand(id, displayOrder, name);
        }
    }
}
