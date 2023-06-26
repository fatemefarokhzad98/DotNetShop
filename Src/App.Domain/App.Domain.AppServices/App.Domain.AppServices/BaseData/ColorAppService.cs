﻿using App.Domain.Core.BaseData.Contracts.AppServices;
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
        private readonly IColorSurenessService _colorSurenessService;
        private readonly IColorService _colorService;
        public ColorAppService(IColorSurenessService colorSurenessService,IColorService colorService)
        {
            _colorSurenessService = colorSurenessService;
            _colorService = colorService;

        }
        public async Task<ColorDto> GetColor(int id)
        {
          return  await _colorService.GetColor(id);
           
        }

        public async Task<ColorDto> GetColor(string name)
        {
            return await _colorService.GetColor(name);
        }

        public async Task<List<ColorDto>> GetColors()
        {
            return await _colorService.GetColors();
        }

        public async Task InsertColor(string name, string colorCode,bool isDeleted)
        {
            await _colorSurenessService.EnsureColorIsNotExist(name);
            await _colorService.InsertColor(name, colorCode,isDeleted);
        }

        public async Task RemoveColor(int id)
        {
            await _colorSurenessService.EnsureColorIsExist(id);
            await _colorService.RemoveColor(id);
        }

        public  async Task UpdateColor(int id, string name, string colorCode,bool isDeleted)
        {
            await _colorSurenessService.EnsureColorIsExist(id);
            await _colorService.UpdateColor(id, name, colorCode,isDeleted);
            
        }
    }
}
