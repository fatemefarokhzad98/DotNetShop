using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
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

        public async Task< BrandDto> GetBrand(int id)
        {
         var brand=await _brandQueryRepository.GetBrand(id);
            if (brand == null)
                throw new Exception();
            return brand;
        }

        public async Task< BrandDto> GetBrand(string name)
        {
            var brand = await  _brandQueryRepository.GetBrand(name);
            if (brand == null)
                throw new Exception();
            return brand;
        }

        public async Task< List<BrandDto>> GetBrands()
        {
           return await _brandQueryRepository.GetBrnds();
        }

        public async Task RemoveBrand(int id)
        {
          await  _brandCommandRepository.RemoveBrand(id);
        }

        public async Task  SetBrand(int displayOrder, string name)
        {
          await  _brandCommandRepository.CreateBrand( name, displayOrder, DateTime.Now,false);
        }

        public async Task UpdateBrand(int id, int displayOrder, string name)
        {
          await  _brandCommandRepository.UpdateBrand(name, displayOrder, id,DateTime.Now);
        }
    }
}
