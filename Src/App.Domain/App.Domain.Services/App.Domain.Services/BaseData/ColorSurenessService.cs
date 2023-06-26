using App.Domain.Core.BaseData.Contracts.Repositories;
using App.Domain.Core.BaseData.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Services.BaseData
{
    public class ColorSurenessService : IColorSurenessService
    {
        private readonly IColorQueryRepository _colorQueryRepository;
        public ColorSurenessService(IColorQueryRepository colorQueryRepository )
        {
            _colorQueryRepository = colorQueryRepository;


        }
        public async Task EnsureColorIsExist(string name)
        {
            var color= await _colorQueryRepository.GetColor(name);
            if (color == null)
                throw new Exception();
        }

        public async Task EnsureColorIsExist(int id)
        {
            var color = await _colorQueryRepository.GetColor(id);
            if (color == null)
                throw new Exception();
        }

        public async Task EnsureColorIsNotExist(int id)
        {
            var color = await _colorQueryRepository.GetColor(id);
            if (color != null)
                throw new Exception();
        }

        public async Task EnsureColorIsNotExist(string name)
        {
            var color = await _colorQueryRepository.GetColor(name);
            if (color != null)
                throw new Exception();

        }
    }
}
