using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class BrandCommandRepository : IBrandCommandRepository
    {

        private readonly AppDbContext _appDbContext;
        public BrandCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;


        }
        public void CreateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }

        public void RemoveBrand(int Id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBrand(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
