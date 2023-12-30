using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IStatusSurnessService
    {
        Task EnsureModelIsNotExist(string title);
        Task EnsureModelIsExist(int id);
    }
}
