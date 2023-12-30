using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Contracts.AppServices
{
    public interface IColorAppService
    {
        Task UpdateColor(int id, string name, string colorCode);
        Task InsertColor(string name, string colorCode);
        Task RemoveColor(int id);
        Task<List<ColorDto>> GetColors();
        Task<ColorDto?> GetColor(int id);
        Task<ColorDto?> GetColor(string code);

    }
}
