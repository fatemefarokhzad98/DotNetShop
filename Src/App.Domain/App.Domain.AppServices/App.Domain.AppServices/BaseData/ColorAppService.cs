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
        private readonly ISurenessService _colorSurenessService;
        private readonly IColorService _colorService;
        public ColorAppService(ISurenessService colorSurenessService,IColorService colorService)
        {
            _colorSurenessService = colorSurenessService;
            _colorService = colorService;

        }
        public async Task<ColorDto> GetColor(int id)
        {
            var color = await _colorService.GetColor(id);
            if (color == null)
                throw new Exception();
            return color;


        }

        public async Task<ColorDto> GetColor(string name)
        {
            var color= await _colorService.GetColor(name);
            if (color == null)
                throw new Exception();
            return color;
            
        }

        public async Task<List<ColorDto>> GetColors()
        {
            return await _colorService.GetColors();
        }

        public async Task InsertColor(string name, string colorCode,bool isDeleted)
        {
            await _colorSurenessService.EnsureModelIsNotExist(name);
            await _colorService.InsertColor(name, colorCode,isDeleted);
        }

        public async Task RemoveColor(int id)
        {
            await _colorSurenessService.EnsureModelIsExist(id);
            await _colorService.RemoveColor(id);
        }

        public  async Task UpdateColor(int id, string name, string colorCode,bool isDeleted)
        {
            await _colorSurenessService.EnsureModelIsExist(id);
            await _colorService.UpdateColor(id, name, colorCode,isDeleted);
            
        }
    }
}
