using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IColorSurenessService
    {
        Task EnsureColorIsNotExist(int id);
        Task EnsureColorIsNotExist(string name);
       Task  EnsureColorIsExist(string name);
        Task EnsureColorIsExist(int id);


    }
}
