using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Contracts.Services
{
    public interface IProductSurnessService
    {
        Task EnsureModelIsNotExist(int id);
        Task EnsureModelIsNotExist(string name);
        Task EnsureModelIsExist(int id);
        Task EnSureModelIsExist(string name);
    }
}
