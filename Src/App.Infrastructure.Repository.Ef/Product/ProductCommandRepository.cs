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
using App.Domain.Core.Product.Entities;

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
            _appDbContext.Product.Add(productInsert);
            await _appDbContext.SaveChangesAsync();

         
            foreach(var color in product.Colors)
            {
                var _color = new ProductColor()
                {
                    ColorId=color.Id,
                    ProductId=productInsert.Id
                   

                };
                productInsert.ProductColors.Add(_color);
            }
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

            productUpdate.Id = product.Id;
            productUpdate.BrandId = product.BrandId;
            productUpdate.SubmitEditTime = DateTime.Now;
            productUpdate.CategoryId = product.CategoryId;
            productUpdate.ModelId = product.ModelId;
            productUpdate.StatusId = product.StatusId;
            productUpdate.Count = product.Count;
            productUpdate.Description = product.Description;
            productUpdate.IsActive = product.IsActive;
            productUpdate.IsDeleted = false;
            productUpdate.IsOrginal = product.IsOrginal;
            productUpdate.IsShowPrice = product.IsShowPrice;
            productUpdate.Name = product.Name;
            productUpdate.Price = product.Price;
            productUpdate.SubmitTime = product.SubmitTime;
            productUpdate.OperatorEdit = product.EditUserName;
           
            
            var productColors = new List<ProductColor>();
            foreach (var color in product.Colors)
            {
                ProductColor productColor = new ProductColor
                {

                    ProductId =productUpdate.Id,
                    ColorId = color.Id,
                 
                };
                productColors.Add(productColor);
            }
           productUpdate.ProductColors=productColors;
            await _appDbContext.SaveChangesAsync();
            return productUpdate.Id;

        }
    }
}
