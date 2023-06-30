using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColorCommandRepository
    {
        Task UpdateColor(int id ,string name,string colorCode);
        Task InsertColor( string name, string colorCode, bool isDeleted);
        Task RemoveColor(int id);
    }
}
