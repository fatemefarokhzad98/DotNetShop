using App.Domain.Core.Product.Contracts.Repositories;
using App.Domain.Core.Product.Entities;
using App.Infrastructure.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Servises
{
    public class BrandRepository : IBrandRepository
    {
        public BrandRepository(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        private readonly AppDbContext _AppDbContext;

        public void CreateBrand(Brand brand)
        {
           _AppDbContext.Brands.Add(brand);
            _AppDbContext.SaveChanges();

           
        }

        public bool Exist(int Id)
        {
            var brand= _AppDbContext.Brands.Any(x=> x.Id == Id);
            return brand;
            
        }

        public List<Brand> GetAllBrnds()
        {
            var brands = _AppDbContext.Brands.ToList();
            return brands;

          
        }

        public void RemoveBrand(int Id)
        {
            var brand = _AppDbContext.Brands.Where(x => x.Id == Id).FirstOrDefault();
            if (brand != null)
            _AppDbContext.Remove(brand);
            _AppDbContext.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            var _brand = _AppDbContext.Brands.Where(x => x.Id == brand.Id).FirstOrDefault();
            if (_brand != null)
            {
                _brand.Name = brand.Name;
                _brand.DisplayOrder = brand.DisplayOrder;
                _brand.Products = brand.Products;
                _brand.Models = brand.Models;
            }
            _AppDbContext.SaveChanges();


            
        }
    }
}
