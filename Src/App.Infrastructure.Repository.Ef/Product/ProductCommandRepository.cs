using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Dtos;

using ProductEntities = App.Domain.Core.Product.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;

namespace App.Infrastructure.Repository.Ef.Product
{
    public class ProductCommandRepository:IProductCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> InsertProduct(ProductInsertDto product)
        {
            ProductEntities.Product productInsert = new()
            {
                BrandId = product.BrandId,
                CategoryId=product.CategoryId,
                Count=product.Count,
                Description=product.Description,
                IsActive=product.IsActive,
                 IsOrginal=product.IsOrginal,
                 IsDeleted=false,
                 IsShowPrice=product.IsShowPrice,
                 ModelId=product.ModelId,
                 Name=product.Name,
                 StatusId=product.StatusId,
                 Price=product.Price,
              
                 SubmitTime=DateTime.Now ,
                 
           
            };

            await _appDbContext.Product.AddAsync(productInsert);
            await _appDbContext.SaveChangesAsync();
            return productInsert.Id;

        }

        public async Task<ProductDto> RemoveProduct(int id)
        {
            var product = await _appDbContext.Product.Where(x => x.Id == id).SingleAsync();
            var productDto = await _appDbContext.Product.Where(x => x.Id == id).AsNoTracking().Select(p => new ProductDto()
            {
                Id = id,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Name = p.Name,
                CategoryId = p.CategoryId,
                CategoryName = p.Category.Name,
                ModelId = p.ModelId,
                ModelName = p.Model!.Name,
                Count = p.Count,
                Description = p.Description,
                IsActive = p.IsActive,
                IsDeleted = p.IsDeleted,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                Price = p.Price,
                StatusId = p.StatusId,
                StatusName = p.Status.Title,
                SubmitTime = DateTime.Now


            }).FirstOrDefaultAsync();
             _appDbContext.Remove(product);
            return productDto;
        }
        public async Task<int> UpdateProduct(ProductDto product)
        {

            var productUpdate = await _appDbContext.Product.Where(x => x.Id == product.Id).SingleAsync();
            ProductEntities.Product productDtoUpdate = new()
            {

                Id = product.Id,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelId = product.ModelId,
                StatusId = product.StatusId,
                Count = product.Count,
                Description = product.Description,
                IsActive = product.IsActive,
                IsDeleted = false,
                IsOrginal = product.IsOrginal,
                IsShowPrice = product.IsShowPrice,
                Name = product.Name,
                Price = product.Price,
                SubmitTime = DateTime.Now,
             
            };
            _appDbContext.Update(productDtoUpdate); 
            await _appDbContext.SaveChangesAsync();
            return productDtoUpdate.Id;

        }
    }
}
