
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandCommandRepository
    {
       
        Task CreateBrand(string name,int displayOrder,DateTime dateTime,bool isDeleted);
        Task UpdateBrand(string name, int displayOrder,int id,DateTime dateTime);
        Task RemoveBrand(int id);
       
      

    }
}
