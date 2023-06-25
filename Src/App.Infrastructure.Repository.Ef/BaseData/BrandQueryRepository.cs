using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
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

        public List<BrandDto> GetBrnds()
        {
           return _appDbContext.Brands.AsNoTracking().Select(b => new BrandDto()
            {
                Id=b.Id,
                 Name=b.Name,
                 CreationDate=b.CreationDate,
                 DisplayOrder=b.DisplayOrder,
                 IsDeleted=b.IsDeleted 


            }).ToList();
        }

        public BrandDto? GetBrand(int Id)
        {
            return _appDbContext.Brands.AsNoTracking().Where(b => b.Id == Id).Select(p => new BrandDto()
            {
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                Id = p.Id,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted

            }).FirstOrDefault();

        }

        public BrandDto? GetBrand(string Name)
        {
            return _appDbContext.Brands.AsNoTracking().Where(b => b.Name == Name).Select(p => new BrandDto()
            {
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                Id = p.Id,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted

            }).SingleOrDefault();
           
        }
    }
}
