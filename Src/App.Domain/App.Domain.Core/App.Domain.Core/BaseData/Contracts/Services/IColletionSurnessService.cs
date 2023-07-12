using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IColletionSurnessService
    {
        Task EnsureModelIsNotExist(int id);
        Task EnsureModelIsNotExist(string name);
        Task EnsureModelIsExist(int id);
        Task EnSureModelIsExist(string name);
    }
}
