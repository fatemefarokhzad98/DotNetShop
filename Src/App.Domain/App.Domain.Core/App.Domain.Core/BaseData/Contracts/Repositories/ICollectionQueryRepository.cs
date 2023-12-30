using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface ICollectionQueryRepository
    {
        Task<List<CollectionDto>?> GetCollection();
        Task<CollectionDto?>GetCollection(int id);
        Task<CollectionDto?>GetCollection(string name);
        

    }
}
