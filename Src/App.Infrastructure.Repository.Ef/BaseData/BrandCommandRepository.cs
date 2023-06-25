﻿using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
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
       

        public void CreateBrand(string name, int displayOrder, DateTime dateTime, bool isDeleted)
        {
            Brand brand = new()
            {
                Name = name,
                CreationDate = dateTime,
                IsDeleted = isDeleted,
                DisplayOrder = displayOrder,

            };
            _appDbContext.Add(brand);
            _appDbContext.SaveChanges();
        }

        public void RemoveBrand(int Id)
        {


        }

        public void UpdateBrand(Brand brand)
        {
           
        }
    }
}
