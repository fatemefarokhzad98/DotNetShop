using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
using App.Infrastructure.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class ColorQueryRepository : IColorQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ColorQueryRepository(AppDbContext appDbContext )
        {
            _appDbContext = appDbContext;

        }
        public async Task<ColorDto?> GetColor(int id)
        {
            var color = await _appDbContext.Colors.AsNoTracking().Where(x => x.Id == id).Select(c => new ColorDto()
            {
                Id = c.Id,
                Name = c.Name,
                ColorCode = c.ColorCode,
                IsDeleted=c.IsDeleted
                
            }).SingleOrDefaultAsync();
            return color;
        }

        public  async Task<ColorDto?> GetColor(string name)
        {
            var color = await _appDbContext.Colors.AsNoTracking().Where(x => x.Name == name).Select(c => new ColorDto()
            {
                Id = c.Id,
                Name = c.Name,
                ColorCode = c.ColorCode,
                IsDeleted=c.IsDeleted
                
            }).FirstOrDefaultAsync();
            return color;
        }

        public async Task<List<ColorDto>> GetColors()
        {
            var color = await _appDbContext.Colors.AsNoTracking().Select(x => new ColorDto()
            {
                Id = x.Id,
                Name = x.Name,
                ColorCode = x.ColorCode,
                IsDeleted=x.IsDeleted
                
            }).ToListAsync();
            return color;
        }


    }
}
