using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Services
{
    public interface IBrandSurenessService
    {
        void EnsureBrandIsNotExist(int brandId);
        void EnsureBrandIsNotExist(string brandName);
        void EnsureBrandIsExist(int brandId);
        void EnSureBrandIsExist(string brandName);

    }
}
