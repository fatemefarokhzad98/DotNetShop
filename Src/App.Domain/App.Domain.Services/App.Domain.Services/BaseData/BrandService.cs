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

        public BrandDto GetBrand(int id)
        {
          return  _brandQueryRepository.GetBrand(id);
        }

        public BrandDto GetBrand(string name)
        {
            return _brandQueryRepository.GetBrand(name);
        }

        public List<BrandDto> GetBrands()
        {
           return _brandQueryRepository.GetBrnds();
        }

        public void RemoveBrand(int id)
        {
            throw new NotImplementedException();
        }

        public void SetBrand(int displayOrder, string name)
        {
            _brandCommandRepository.CreateBrand( name, displayOrder, DateTime.Now,false);
        }

        public void UpdateBrand(int id, int displayOrder, string name)
        {
            throw new NotImplementedException();
        }
    }
}
