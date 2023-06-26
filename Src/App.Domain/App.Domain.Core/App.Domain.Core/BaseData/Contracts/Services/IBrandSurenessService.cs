using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IBrandSurenessService
    {
        Task EnsureBrandIsNotExist(int brandId);
        Task EnsureBrandIsNotExist(string brandName);
        Task EnsureBrandIsExist(int brandId);
        Task EnSureBrandIsExist(string brandName);

    }
}
