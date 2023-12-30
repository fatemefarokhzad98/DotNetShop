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
    public class BrandQueryRepository : IBrandQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public BrandQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task<List<ProductBriefDto>?> GetBrandsWithProduct(int? id,string? name)
        {
            List<ProductBriefDto> products = new List<ProductBriefDto>();

            var product = await _appDbContext.Product.Where(x => x.BrandId == id && x.IsDeleted == false || x.Brand.Name == name && x.IsDeleted == false).ToListAsync();
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

        public async Task<BrandDto?> GetBrand(string Name)
        {
            return await _appDbContext.Brand.AsNoTracking().Where(b => b.Name == Name &&b.IsDeleted==false).Select(p => new BrandDto()
            {
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                Id = p.Id,
                CreationDate = p.CreationDate,
                IsDeleted = p.IsDeleted

            }).SingleOrDefaultAsync();

        }
        public async Task<List<BrandDto>?> GetBrands()
        {

            return await _appDbContext.Brand.AsNoTracking().Where(x=>x.IsDeleted==false).Select(p => new BrandDto()
            {
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                Id = p.Id,
                CreationDate = p.CreationDate,
                IsDeleted =false
                

            }).ToListAsync();
        }
        public async Task<BrandDto?> GetBrand(int id)
        {
            return await _appDbContext.Brand.AsNoTracking().Where(b => b.Id == id && b.IsDeleted==false).Select(p => new BrandDto()
            {
                Name = p.Name,
                DisplayOrder = p.DisplayOrder,
                Id = p.Id,
                CreationDate = p.CreationDate,
                IsDeleted = false
                

            }).SingleOrDefaultAsync();

        }
    }
}
