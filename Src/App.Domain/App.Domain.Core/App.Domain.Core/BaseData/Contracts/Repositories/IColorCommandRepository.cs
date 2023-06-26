using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColorCommandRepository
    {
        Task UpdateColor(int id ,int name,string ColorCode);
        Task InsertColor(int id, int name, string ColorCode);
        Task RemoveColor(int id);
    }
}
