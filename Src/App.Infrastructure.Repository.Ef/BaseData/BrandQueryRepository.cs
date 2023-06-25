using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class BrandQueryRepository: IBrandQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public BrandQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;


        }

        public List<BrandDto> GetAllBrnds()
        {
            throw new NotImplementedException();
        }

        public BrandDto? GetBrand(int Id)
        {
            throw new NotImplementedException();
        }

        public BrandDto? GetBrand(string Name)
        {
            throw new NotImplementedException();
        }
    }
}
