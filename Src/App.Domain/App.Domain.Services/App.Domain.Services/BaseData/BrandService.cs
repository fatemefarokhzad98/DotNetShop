using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class BrandService: IBrandService
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        public BrandService(IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;

        }

        public async Task CreateBrand(string name, int displayOrder)
        {

            await _brandCommandRepository.CreateBrand(name, displayOrder,DateTime.Now, false);
        }

        public async Task<BrandDto?> GetBrand(int id)
        {
            var brand= await _brandQueryRepository.GetBrand(id);
            if (brand==null)
            {
                throw new Exception();

            }
            return brand;
        }

        public async Task<BrandDto?> GetBrand(string Name)
        {
            var brand=await _brandQueryRepository.GetBrand(Name);
            if (brand == null)
            {
                throw new Exception();

            }
            return brand;

        }

        public async Task<List<BrandDto>?> GetBrands()
        {
            var brand=await _brandQueryRepository.GetBrands();
            if (brand == null)
            {
                throw new Exception();

            }
            return brand;
        }

        public async Task<List<ProductBriefDto>?> GetBrandsWithProduct(int? id, string? name)
        {
            var product=await _brandQueryRepository.GetBrandsWithProduct(id, name);
            if (product==null)
            {
                throw new Exception();
            }
            return product;
        }

        public async Task RemoveBrand(int id)
        {
             await _brandCommandRepository.RemoveBrand(id);
        }

        public async Task UpdateBrand(string name, int displayOrder, int id)
        {
             await _brandCommandRepository.UpdateBrand(name, displayOrder, id);
        }
    }
}
