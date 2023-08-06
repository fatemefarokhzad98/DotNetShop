using App.Domain.Core.BaseData.Contracts.AppServices;
using App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData;
using Microsoft.AspNetCore.Mvc;


namespace App.EndPoint.ShopUi.Area.Admin.Controllers.BaseData
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorAppService _colorAppService;
        public ColorController(IColorAppService colorAppService)
        {
            _colorAppService = colorAppService;

        }
        [HttpGet]
        public async Task<IActionResult> ReadColor()
        {
         var color= await  _colorAppService.GetColors();
            var colorMolel =  color.Select(c => new ColorReadViewModel()
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
        public async Task<IActionResult> InsertColor(ColorInsertViewModel color )
        {
            if (ModelState.IsValid)
            {



                await _colorAppService.InsertColor(color.Name, color.ColorCode);
                return RedirectToAction("ReadColor");
            }
            return View(color);
           
        }

        [HttpPost]
        public async Task<IActionResult> UpdateColor(ColorUpdateViewModel color)
        {
            if (ModelState.IsValid)
            {


                await _colorAppService.UpdateColor(color.Id, color.Name, color.ColorCode);

                return RedirectToAction("ReadColor");
            }
            return View(color);

        }
        [HttpGet]
        public async Task<IActionResult> UpdateColor(int id)
        {
            var color = await _colorAppService.GetColor(id);
            ColorUpdateViewModel colorviewmodel = new()
            {
                Id=id,
                Name=color.Name,
                ColorCode=color.ColorCode,
             

            };
            return View(colorviewmodel);

            
        }
        public async Task <IActionResult> RemoveColor(int id)
        {
            await _colorAppService.RemoveColor(id);
            return RedirectToAction("ReadColor");
        }


    }
}
