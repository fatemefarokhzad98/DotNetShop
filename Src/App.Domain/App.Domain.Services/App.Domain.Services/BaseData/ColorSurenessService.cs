using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ColorSurenessService : ISurenessService
    {
        private readonly IColorQueryRepository _colorQueryRepository;
        private readonly ICategoryCommandRepository _categoryCommandRepository;
        public ColorSurenessService(IColorQueryRepository colorQueryRepository,ICategoryCommandRepository categoryCommandRepository )
        {
            _colorQueryRepository = colorQueryRepository;
            _categoryCommandRepository = categoryCommandRepository;


        }
      

        public async Task EnsureModelIsExist(int id)
        {
            var color = await _colorQueryRepository.GetColor(id);
            if (color == null)
                throw new Exception();
        }

        public  async Task EnSureModelIsExist(string name)
        {
            var color = await _colorQueryRepository.GetColor(name);
            if (color == null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(int id)
        {
            var color = await _colorQueryRepository.GetColor(id);
            if (color != null)
                throw new Exception();
        }

        public async Task EnsureModelIsNotExist(string name)
        {
            var color = await _colorQueryRepository.GetColor(name);
            if (color != null)
                throw new Exception();
        }
    }
}
