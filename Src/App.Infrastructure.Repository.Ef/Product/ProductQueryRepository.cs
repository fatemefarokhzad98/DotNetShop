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
    public class ProductQueryRepository:IProductQueryRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ProductDto?> GetProduct(int id)
        {
            var product = await _appDbContext.Products.Where(x => x.Id == id).AsNoTracking().Select(p => new ProductDto()
            {

                Id = id,
                BrandId = p.BrandId,
                BrandName = p.Brand.Name,
                Name = p.Name,
                CategoryId = p.CategoryId,
                CategoryName=p.Category.Name,
                Count=p.Count,
                Description=p.Description,
                IsActive=p.IsActive,
                IsDeleted=p.IsDeleted,
                IsOrginal=p.IsOrginal,
                IsShowPrice=p.IsShowPrice,
                ModelId=p.ModelId,
                ModelName=p.Model.Name,
                Price=p.Price,
                StatusId=p.StatusId,
                 StatusName=p.Status.Title,
                 SubmitOperatorId=p.SubmitOperatorId,
                 SubmitTime=p.SubmitTime,
                 SubmitOperatorName=p.SubmitOperator.UserName


            }).FirstOrDefaultAsync();
            return product;

        }

        public async Task<ProductDto?> GetProduct(string name)
        {
            var product = await _appDbContext.Products.Where(x => x.Name == name).AsNoTracking().Select(p => new ProductDto()
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
                IsDeleted = p.IsDeleted,
                IsOrginal = p.IsOrginal,
                IsShowPrice = p.IsShowPrice,
                ModelId = p.ModelId,
                ModelName = p.Model.Name,
                Price = p.Price,
                StatusId = p.StatusId,
                StatusName = p.Status.Title,
                SubmitOperatorId = p.SubmitOperatorId,
                SubmitTime = p.SubmitTime,
                SubmitOperatorName = p.SubmitOperator.UserName
            }).SingleOrDefaultAsync();
            return product;


        }

        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _appDbContext.Products.AsNoTracking().Select(p => new ProductDto()
            {

                BrandId = p.BrandId,
                BrandName=p.Brand.Name,
                Name=p.Name,
                CategoryId=p.CategoryId,
                CategoryName=p.Category.Name,
                Count=p.Count,
                Description=p.Description,
                Id=p.Id,
                IsActive=p.IsActive,
                IsDeleted=p.IsDeleted,
                IsOrginal=p.IsOrginal,
                IsShowPrice=p.IsShowPrice,
                ModelId=p.ModelId,
                ModelName=p.Model.Name,
                Price=p.Price,
                StatusId=p.StatusId,
                StatusName=p.Status.Title,
                SubmitOperatorId=p.SubmitOperatorId,
                SubmitOperatorName=p.SubmitOperator.UserName,
                SubmitTime=p.SubmitTime
 
            }).ToListAsync();
            return products;

        }
    }
}
