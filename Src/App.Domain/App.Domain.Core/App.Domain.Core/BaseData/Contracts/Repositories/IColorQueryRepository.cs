using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.Repositories
{
    public interface IColorQueryRepository
    {

        Task<List<ColorDto>> GetColors();
        Task<ColorDto> GetColor(int id);
        Task<ColorDto> GetColor(string name);
    }
}
