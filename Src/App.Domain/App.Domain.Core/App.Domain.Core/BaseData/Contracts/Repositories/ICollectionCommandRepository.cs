using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface ICollectionCommandRepository
    {
        Task<int> UpdateCollection(string name,int id);
        Task<CollectionDto> RemoveCollection(int id);
        Task<int> InsertCollection(string name,bool isDeleted,DateTime CreationDate);
    }
}
