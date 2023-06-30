using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ColorService : IColorService
    {
        private readonly IColorCommandRepository _colorCommandRepository;
        private readonly IColorQueryRepository _colorQueryRepository;
      

        public ColorService(IColorCommandRepository colorCommandRepository,IColorQueryRepository colorQueryRepository )
        {
            _colorCommandRepository = colorCommandRepository;
            _colorQueryRepository = colorQueryRepository;
            


        }
        public async Task<ColorDto> GetColor(int id)
        {
          return  await _colorQueryRepository.GetColor(id);
            
            
        }

        public async Task<ColorDto> GetColor(string name)
        {
            return await _colorQueryRepository.GetColor(name);
           
        }

        public async Task<List<ColorDto>> GetColors()
        {
            return await _colorQueryRepository.GetColors();
           
        }

        public async Task InsertColor(string name, string colorCode)
        {
           
            await _colorCommandRepository.InsertColor(name,colorCode,false);
        }

        public async Task RemoveColor(int id)
        {
           
            await _colorCommandRepository.RemoveColor(id);
        }

        public async Task UpdateColor(int id, string name, string colorCode)
        {
           
            await _colorCommandRepository.UpdateColor(id, name, colorCode);
        }
    }
}
