using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Dtos;
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
    public class ModelCommandRepository: IModelCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModelCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> InsertModel(int brandid, bool isDeleted, int? parentModelId, string name)
        {
            Model model = new()
            {
                BrandId = brandid,
                IsDeleted = isDeleted,
                Name = name,
                ParentModelId = parentModelId,

            };
             await _appDbContext.Modell.AddAsync(model);
            await _appDbContext.SaveChangesAsync();
            return model.Id;
           

        }

        public async Task<ModelDto> RemoveModel(int id)
        {
            var model = await _appDbContext.Modell.Where(x => x.Id == id).SingleAsync();
            var modelDto = await _appDbContext.Modell.Where(x => x.Id == id).AsNoTracking().Select(c => new ModelDto()
            {
                Id = c.Id,
                BrandId = c.BrandId,
                IsDeleted = c.IsDeleted,
                Name = c.Name,
                ParentModelId =c.ParentModelId

            }).FirstOrDefaultAsync();
            _appDbContext.Remove(model);
          await  _appDbContext.SaveChangesAsync();
            return modelDto;

        }

        public async Task<int> UpdateModel(int brandid, int ?parentModelId, string name, int id)
        {
            var model = await _appDbContext.Modell.Where(x=>x.Id==id).SingleAsync();
            model.Name= name;
           
            model.BrandId= brandid;
            model.ParentModelId= parentModelId;
            await _appDbContext.SaveChangesAsync();
            return model.Id;
        }
    }
}
