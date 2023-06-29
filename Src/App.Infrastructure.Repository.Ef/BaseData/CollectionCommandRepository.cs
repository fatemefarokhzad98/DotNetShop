using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Infrastructure.DataBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repository.Ef.BaseData
{
    public class CollectionCommandRepository: ICollectionCommandRepository
    {
        private readonly AppDbContext _appDbContext;
        public CollectionCommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
