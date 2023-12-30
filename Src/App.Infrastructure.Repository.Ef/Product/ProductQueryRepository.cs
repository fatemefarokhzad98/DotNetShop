using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.Product
{
    public class ProductQueryRepository : IProductQueryRepository
    {
        private readonly AppDbContext _appDbContext;
         
        public ProductQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProductReadDto?> GetProduct(int id)
        {
            var product = await _appDbContext.Product.AsNoTracking().Where(x => x.Id == id && x.IsDeleted == false).Select(p => new ProductReadDto()
            {

                Id = id,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Name = p.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Count = p.Count,
                Description = p.Description,
                IsActive = p.IsActive,
                IsDeleted = false,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                ModelName = p.Model!.Name,
                Price = p.Price,
                StatusId = p.StatusId,
                StatusName = p.Status.Title,
                SubmitTime = p.SubmitTime,
                SubmitEditTime = p.SubmitEditTime,
                 ImangeName=p.ImageName,
                  UserSubmitName=p.OperatorInsert,
                  UserEditName=p.OperatorEdit,
                   
                Colors=p.ProductColors.Select(x=>new Domain.Core.BaseData.Dtos.ColorDto()
                {
                    Id=x.Id,
                    ColorCode=x.Color.ColorCode,
                    Name=x.Color.Name,
                    IsDeleted=false

                }).ToList()
            }).FirstOrDefaultAsync();
            return product;

        }

        public async Task<List<ProductReadDto>?> GetProduct(string name)
        {
            var product = await _appDbContext.Product.AsNoTracking().Where(x => x.Name == name && x.IsDeleted == false).Select(p => new ProductReadDto()
            {
                Name = p.Name,
                Id = p.Id,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,

                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Count = p.Count,
                Description = p.Description,
                IsActive = p.IsActive,
                IsDeleted = false,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                ModelName = p.Model!.Name,
                Price = p.Price,
                StatusId = p.StatusId,
                StatusName = p.Status.Title,
                SubmitTime = p.SubmitTime,
                SubmitEditTime = p.SubmitEditTime,
                 ImangeName=p.ImageName,
                UserSubmitName = p.OperatorInsert,
                UserEditName = p.OperatorEdit,
                Colors = p.ProductColors.Select(x => new Domain.Core.BaseData.Dtos.ColorDto()
                {
                    Id = x.Id,
                    ColorCode = x.Color.ColorCode,
                    Name = x.Color.Name,
                    IsDeleted = false

                }).ToList(),
                SubmitRemoveTime = p.SubmitRemoveTime


            }).ToListAsync();
            return product;


        }

        public async Task<List<ProductReadDto>> GetProducts()
        {
            var products = await _appDbContext.Product.AsNoTracking().Where(x => x.IsDeleted == false).Select(p => new ProductReadDto()
            {

                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Name = p.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                Count = p.Count,
                Description = p.Description,
                Id = p.Id,
                IsActive = p.IsActive,
                IsDeleted = false,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                ModelName = p.Model!.Name,
                Price = p.Price,
                StatusId = p.StatusId,
                StatusName = p.Status.Title,
                SubmitTime = p.SubmitTime,
                SubmitEditTime=p.SubmitEditTime,
                ImangeName=p.ImageName,
                UserSubmitName = p.OperatorInsert,
                UserEditName = p.OperatorEdit,
                Colors = p.ProductColors.Select(x => new Domain.Core.BaseData.Dtos.ColorDto()
                {
                    Id = x.Id,
                    ColorCode = x.Color.ColorCode,
                    Name = x.Color.Name,
                    IsDeleted = false

                }).ToList(),
                SubmitRemoveTime = p.SubmitRemoveTime

            }).ToListAsync();
            return products;

        }

        public async Task<List<ProductBriefDto>>? Search(int? categoryId, string? keyWord, int? minPrice, int? maxPrice, int? brandId)
        {
            var product = await _appDbContext.Product.AsNoTracking()

                 .Where(x => (categoryId == null || x.CategoryId == categoryId))
                 .Where(x => (keyWord == null || keyWord == "" || x.Description.Contains(keyWord) || x.Name.Contains(keyWord)))
                 .Where(x => (minPrice == null || x.Price >= minPrice))
                 .Where(x => (maxPrice == null || x.Price <= maxPrice))
                 .Where(x => (brandId == null || x.BrandId == brandId))
                 .Select(x => new ProductBriefDto()
                 {
                     Id = x.Id,
                     Name = x.Name,
                     IsDeleted = x.IsDeleted,
                     IsOrginal = x.IsOrginal,
                     Price = x.Price,
                     Count = x.Count,
                     CategoryName = x.Category.Name,
                     BrandName = x.Brand.Name,
                      ImageName=x.ImageName,
                     Colors = x.ProductColors.Select(c => new Domain.Core.BaseData.Dtos.ColorDto() {
                         Id=c.Id,
                         Name=c.Color.Name,
                         ColorCode=c.Color.ColorCode,
                         IsDeleted=false

                     }).ToList(),

                 }).ToListAsync();

            return product;



        }
    }
}
