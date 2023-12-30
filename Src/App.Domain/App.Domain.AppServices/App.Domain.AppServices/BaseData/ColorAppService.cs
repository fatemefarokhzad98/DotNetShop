using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppServices.BaseData
{
    public class ColorAppService : IColorAppService
    {
        private readonly IColorSurnessService _colorSurenessService;
        private readonly IColorService _colorService;
        public ColorAppService(IColorSurnessService colorSurenessService,IColorService colorService)
        {
            _colorSurenessService = colorSurenessService;
            _colorService = colorService;

        }
      
        public async Task<ColorDto?> GetColor(int id)
        {
            return await _colorService.GetColor(id);
        }

        public async Task<ColorDto?> GetColor(string code)
        {
            return await _colorService.GetColor(code);
        }

        public async Task<List<ColorDto>> GetColors()
        {
            var color= await _colorService.GetColors();
            return color;
        }


        public async Task InsertColor(string name, string colorCode)
        {
          await  _colorSurenessService.EnsureModelIsNotExist(name);
             await _colorService.InsertColor(name, colorCode);
        }

        public async Task RemoveColor(int id)
        {
            await _colorSurenessService.EnsureModelIsExist(id);
            await _colorService.RemoveColor(id);
        }

        public async Task UpdateColor(int id, string name, string colorCode)
        {
           await _colorSurenessService.EnsureModelIsExist(id);
            await _colorService.UpdateColor(id,name, colorCode); 
        }
    }
}
