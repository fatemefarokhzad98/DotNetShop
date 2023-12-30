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
using App.Domain.Core.BaseData.Dtos;

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
                 ImageName=product.ImageName,
                 OperatorInsert=product.SubmitOperatorName
                 
             
            };
           
            List<ColorDto> colorDtos = new List<ColorDto>();
            foreach (var item in product.Colors)
            {
                colorDtos.Add(new ColorDto()
                {
                    Id = item.Id,
                    ColorCode = item.ColorCode,
                    Name = item.Name,
                    IsDeleted = item.IsDeleted
                });

            }
        

             _appDbContext.Product.Add(productInsert);
            await _appDbContext.SaveChangesAsync();
            return productInsert.Id;

        }

        public async Task<int> RemoveProduct(int id,string userRemoveName)
        {
            var product = await _appDbContext.Product.Where(x => x.Id == id).SingleAsync();

            product.IsDeleted = true;
            product.SubmitRemoveTime = DateTime.Now;
            product.OperatorRemove = userRemoveName;
           await _appDbContext.SaveChangesAsync();
            return product.Id;
        }
        public async Task<int> UpdateProduct(ProductDto product)
        {

            var productUpdate = await _appDbContext.Product.Where(x => x.Id == product.Id).SingleAsync();
            ProductEntities.Product productDtoUpdate = new()
            {

                Id = product.Id,
                BrandId = product.BrandId,
                SubmitEditTime=DateTime.Now,
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
                SubmitTime = product.SubmitTime,
                OperatorEdit=product.EditUserName,
            
            };
       
            List<ColorDto> colorDtos = new List<ColorDto>();
            foreach (var item in product.Colors)
            {
                colorDtos.Add(new ColorDto()
                {
                    Id = item.Id,
                    ColorCode = item.ColorCode,
                    Name = item.Name,
                    IsDeleted = item.IsDeleted
                });

            }
            _appDbContext.Update(productDtoUpdate); 
            await _appDbContext.SaveChangesAsync();
            return productDtoUpdate.Id;

        }
    }
}
