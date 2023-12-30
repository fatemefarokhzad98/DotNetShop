using App.Domain.Core.BaseData.Contracts.AppServices;

using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
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
        private readonly IBrandSurnessService _brandSurenessService;

        public BrandAppService(IBrandService brandService , IBrandSurnessService brandSurenessService)
        {
            _brandService = brandService;
            _brandSurenessService = brandSurenessService;

        }

        public async Task CreateBrand(string name, int displayOrder)
        {
            await _brandService.CreateBrand(name, displayOrder);
        }

        public async Task< BrandDto?> GetBrand(int id)
        {
           var model= await _brandService.GetBrand(id);
            if (model==null)
            {
                throw new Exception();

            }
            return model;
        }


        public async Task<BrandDto?> GetBrand(string Name)
        {
            var model = await _brandService.GetBrand(Name);
            if (model == null)
            {
                throw new Exception();

            }
            return model;

        }

        public async Task< List<BrandDto>?> GetBrands()
        { 
           var model= await _brandService.GetBrands();
            if (model == null)
            {
                throw new Exception();

            }
            return model;

        }

        public async Task<List<ProductBriefDto>?> GetBrandsWithProduct(int? id, string? name)
        {
            var product = await _brandService.GetBrandsWithProduct(id, name);
            if (product==null)
            {
                throw new Exception();
            }
            return product;
        }

   

        public async Task RemoveBrand(int id)
        {
            //دسترس چک شود
            await _brandSurenessService.EnsureModelIsExist(id);
            await _brandService.RemoveBrand(id);
        }

       

        public async Task UpdateBrand(string name, int displayOrder, int id)
        {
            await _brandSurenessService.EnsureModelIsExist(id);


            await _brandService.UpdateBrand(name, displayOrder, id);
        }
    }
}
