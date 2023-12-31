﻿using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Entities;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class ColorCommandRepository : IColorCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public ColorCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task InsertColor(string name, string colorCode,bool isDeleted)
        {
            Color color = new()
            {
                
                Name = name,
                ColorCode = colorCode,
                IsDeleted = isDeleted

            };
             _appDbContext.Color.Add(color);
            await _appDbContext.SaveChangesAsync(); 

            
        }

      

        public async Task RemoveColor(int id)
        {
            var color = await _appDbContext.Color.Where(x => x.Id == id).SingleAsync();
            color.IsDeleted = true;

           await _appDbContext.SaveChangesAsync();

        }

        public async Task UpdateColor(int id, string name, string ColorCode,bool isDeleted)
        {
           var color= await _appDbContext.Color.Where(x => x.Id == id).SingleAsync();
            color.Name = name;
            color.Id = id;
            color.ColorCode = ColorCode;
            color.IsDeleted = isDeleted;
             
               
           await _appDbContext.SaveChangesAsync();

           

        }
    }
}
