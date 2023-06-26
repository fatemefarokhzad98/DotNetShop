﻿using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public  class BrandSurenessService: IBrandSurenessService
    {
        private readonly IBrandCommandRepository _brandCommandRepository;
        private readonly IBrandQueryRepository _brandQueryRepository;
        public BrandSurenessService(IBrandCommandRepository brandCommandRepository, IBrandQueryRepository brandQueryRepository)
        {
            _brandCommandRepository = brandCommandRepository;
            _brandQueryRepository = brandQueryRepository;

        }

        public async Task EnsureBrandIsNotExist(int brandId)
        {
            var brand = await _brandQueryRepository.GetBrand(brandId);
            if (brandId != 0)
                throw new Exception();
        

        }
        public async Task EnsureBrandIsNotExist(string brandName)
        {
           var brand= await _brandQueryRepository.GetBrand(brandName);
            if (brand != null)
                throw new Exception();
           
        }
       
        public async Task EnSureBrandIsExist(string brandName)
        {

            var brand = await _brandQueryRepository.GetBrand(brandName);
            if (brand == null)
                throw new Exception();

        }

        public async Task EnsureBrandIsExist(int brandId)
        {
            var brand = await _brandQueryRepository.GetBrand(brandId);
            if (brand == null)

                throw new Exception();
        }
    }
}
