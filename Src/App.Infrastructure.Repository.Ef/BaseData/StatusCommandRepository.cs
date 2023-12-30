
using App.Domain.Core.BaseData.Contracts.Repositories;
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
    public class StatusCommandRepository: IStatusCommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public StatusCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public async Task CreateStatus(string title,bool forComment,bool forProduct,bool isDeleted,bool forOrder)
        {
            Status status = new()
            {
                Title = title,
               
                ForProduct = forProduct,
                ForComment = forComment,
                IsDeleted = false,
                 ForOrder=forOrder


            };
            _appDbContext.Add(status);
            await _appDbContext.SaveChangesAsync();

        } 
        public async Task RemoveStatus(int id)
        {
            var status = await _appDbContext.Status.Where(x => x.Id == id).SingleAsync();
            status.IsDeleted = true;

        await  _appDbContext.SaveChangesAsync();

        }
        public async Task UpdateStatus (int id, string  title,bool forComment,bool forProduct,bool forOrder)
        {
            var status= await _appDbContext.Status.Where(x=>x.Id== id).SingleAsync();
            status.Title = title;
            status.ForOrder = forOrder;
            status.ForComment = forComment;
            status.ForProduct = forProduct;
         
        await  _appDbContext.SaveChangesAsync();

        }

    }
}
