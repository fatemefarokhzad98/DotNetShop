using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Dtos;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class ModelQueryRepository: IModelQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModelQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelDto?> GetModel(string name)
        {
            var model = await _appDbContext.Model.Where(x => x.Name == name && x.IsDeleted==false).AsNoTracking().Select(c => new ModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                BrandId = c.BrandId,
                IsDeleted = false,
                ParentModelId = c.ParentModelId,
                ParentName=c.ParentModel.Name,
                BrandName=c.Brand.Name


            }).SingleOrDefaultAsync();
            return model;
        }

        public async Task<ModelDto?> GetModel(int id)
        {

            var model = await _appDbContext.Model.Where(x => x.Id== id && x.IsDeleted==false).AsNoTracking().Select(c => new ModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                BrandId = c.BrandId,
                IsDeleted = false,
                ParentModelId = c.ParentModelId,
                BrandName=c.Brand.Name,
                ParentName=c.ParentModel.Name


            }).FirstOrDefaultAsync();
            return model;
        }

        public async Task<List<ModelDto>?> GetModels()
        {
            var models = await _appDbContext.Model.AsNoTracking().Where(x=>x.IsDeleted==false).Select(c => new ModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                BrandId = c.BrandId,
                IsDeleted = false,
                ParentModelId = c.ParentModelId,
                ParentName=c.ParentModel.Name,
                BrandName=c.Brand.Name


            }).ToListAsync();
            return models;
        }
        
        public async Task<List<ProductBriefDto>?> GetModelsWithProduct(int? id, string? name)
        {
            List<ProductBriefDto> products = new List<ProductBriefDto>();

            var product = await _appDbContext.Product.Where(x => x.ModelId == id && x.IsDeleted == false || x.Model.Name == name && x.IsDeleted == false).ToListAsync();
            if (product != null)
            {
                foreach (var item in product)
                {
                    products.Add(new ProductBriefDto()
                    {
                        Id = item.Id,
                        BrandName = item.Brand.Name,
                        Name = item.Name,
                        ImageName = item.ImageName,
                        Count = item.Count,
                        IsOrginal = item.IsOrginal,
                        Price = item.Price,
                        IsDeleted = false,
                        CategoryName = item.Category.Name,
                        Colors = item.ProductColors.Select(x => new ColorDto()
                        {
                            Id = x.Id,
                            ColorCode = x.Color.ColorCode,
                            IsDeleted = x.Color.IsDeleted,
                            Name = x.Color.Name
                        }).ToList()
                    });
                }
                return products;

            }
            return null;



        }
    }
}
