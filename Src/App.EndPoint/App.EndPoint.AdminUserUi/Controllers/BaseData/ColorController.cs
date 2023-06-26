using App.Domain.Core.BaseData.Contracts.AppServices;
using App.Domain.Core.BaseData.Dtos;
using App.EndPoint.AdminUserUi.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.AdminUserUi.Controllers.BaseData
{
    public class ColorController : Controller
    {
        private readonly IColorAppService _colorAppService;
        public ColorController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;

        }

        public async Task<IActionResult> ReadColor()
        {
         var color= await  _colorAppService.GetColors();
            var colorMolel = color.Select(c => new ColorOutPutViewModel()
            {
                Name=c.Name,
                ColorCode=c.ColorCode,
                Id=c.Id

            }).ToList();
            return View(colorMolel);
        }
        public  IActionResult InsertColor()
        {
            return View();
            
        }
        [HttpPost]
        public async Task<IActionResult> InsertColor(ColorOutPutViewModel color )
        {

            await _colorAppService.InsertColor( color.Name, color.ColorCode);
            return RedirectToAction("Read");
           


        }

        [HttpPost]
        public async Task<IActionResult> UpdateColor(ColorInPutViewModel color)
        {
            await _colorAppService.UpdateColor(color.Name, color.ColorCode, color.IsDelete, color.Id);


            return RedirectToAction("Read");

        }
        [HttpGet]
        public async Task<IActionResult> UpdateColor(int id)
        {
            var color = await _colorAppService.GetColor(id);
            return View(color);
        }
        public async Task <IActionResult> RemoveColor(int id)
        {
            await _colorAppService.RemoveColor(id);
            return RedirectToAction("Read");
        }


    }
}
