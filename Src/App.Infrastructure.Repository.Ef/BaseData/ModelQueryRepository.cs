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
    public class ModelQueryRepository: IModelQueryRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModelQueryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ModelDto?> GetModel(string name)
        {
            var model = await _appDbContext.Models.Where(x => x.Name == name).AsNoTracking().Select(c => new ModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                BrandId = c.BrandId,
                IsDeleted = c.IsDeleted,
                ParentModelId = c.ParentModelId


            }).SingleOrDefaultAsync();
            return model;
        }

        public async Task<ModelDto?> GetModel(int id)
        {

            var model = await _appDbContext.Models.Where(x => x.Id== id).AsNoTracking().Select(c => new ModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                BrandId = c.BrandId,
                IsDeleted = c.IsDeleted,
                ParentModelId = c.ParentModelId


            }).FirstOrDefaultAsync();
            return model;
        }

        public async Task<List<ModelDto>> ReadModle()
        {
            var models = await _appDbContext.Models.AsNoTracking().Select(c => new ModelDto()
            {
                Id = c.Id,
                Name = c.Name,
                BrandId = c.BrandId,
                IsDeleted = c.IsDeleted,
                ParentModelId = c.ParentModelId


            }).ToListAsync();
            return models;
        }
    }
}
