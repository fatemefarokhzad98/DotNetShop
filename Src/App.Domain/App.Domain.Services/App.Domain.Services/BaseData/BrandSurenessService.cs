using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public  class BrandSurenessService: IBrandSurnessService
    {
       
        private readonly IBrandQueryRepository _brandQueryRepository;
        public BrandSurenessService( IBrandQueryRepository brandQueryRepository)
        {
          
            _brandQueryRepository = brandQueryRepository;

        }

    
        public async Task EnsureModelIsNotExist(int id)
        {
            var brand = await _brandQueryRepository.GetBrand(id);
            if (brand !=null)
                throw new Exception();

        }

        public async Task EnsureModelIsNotExist(string name)
        {
            var brand = await _brandQueryRepository.GetBrand(name);
            if (brand != null)
                throw new Exception();
        }

        public async Task EnsureModelIsExist(int id)
        {
            var brand = await _brandQueryRepository.GetBrand(id);
            if (brand == null)
                throw new Exception();
        }

        public async Task EnsureModelIsExist(string name)
        {
            var brand = await _brandQueryRepository.GetBrand(name);
            if (brand == null)
                throw new Exception();
        }
    }
}
