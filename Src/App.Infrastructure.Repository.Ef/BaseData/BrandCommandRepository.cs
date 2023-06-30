using App.Domain.Core.BaseData.Contracts.Repositories;

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
    public class BrandCommandRepository : IBrandCommandRepository
    {

        private readonly AppDbContext _appDbContext;
        public BrandCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;


        }
       

        public async Task CreateBrand(string name, int displayOrder, DateTime dateTime, bool isDeleted)
        {
            Brand brand = new()
            {
                Name = name,
                CreationDate = dateTime,
                IsDeleted = isDeleted,
                DisplayOrder = displayOrder,

            };
           await _appDbContext.AddAsync(brand);
           await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveBrand(int Id)
        {
            var brand = await _appDbContext.Brands.Where(x => x.Id == Id).SingleAsync();
            _appDbContext.Remove(brand);
           await _appDbContext.SaveChangesAsync();


        }

        public async Task UpdateBrand(string name, int displayOrder,int id)
        {
          var brand=await  _appDbContext.Brands.Where(x => x.Id == id).SingleAsync();
            brand.Name= name;
            brand.DisplayOrder= displayOrder;
            brand.Id= id;
           await _appDbContext.SaveChangesAsync();
        }
    }
}
