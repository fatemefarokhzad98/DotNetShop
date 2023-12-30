using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Contracts.Repositories;
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
    public class ProductCollectionQueryRepository: IProductCollectionQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductCollectionQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ProductBriefDto>?> GetCollectionWithProduct(int? id, string? name)
        {
            List<ProductBriefDto> productDtos = new List<ProductBriefDto>();
            var productCollection = await _appDbContext.ProductCollection.Where(x => x.CollectionId == id && x.Collection.IsDeleted == false || x.Collection.Name == name && x.Collection.IsDeleted == false).ToListAsync();

            foreach (var item in productCollection)
            {
                var product =  _appDbContext.Product.Find(item.ProductId);
                productDtos.Add(new ProductBriefDto()
                {
                    Id = product.Id,
                    BrandName = product.Brand.Name,
                    Name = product.Name,
                    CategoryName = product.Category.Name,
                    Colors = product.ProductColors.Select(x => new ColorDto() { Name = x.Color.Name, ColorCode = x.Color.ColorCode, IsDeleted = x.Color.IsDeleted, Id = x.Id }).ToList(),
                    IsDeleted = product.IsDeleted,
                    Count = product.Count,
                    ImageName = product.ImageName,
                    IsOrginal = product.IsOrginal,
                    Price = product.Price,
                    StatusName = product.Status.Title

                });

            }
            return productDtos;
        }
    }
}
