using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IBrandQueryRepository
    {
        List<Brand> GetAllBrnds();
        
        Brand? GetId (int Id);
        Brand? GetName(string Name);

    }
}
