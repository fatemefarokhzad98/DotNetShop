using App.Domain.Core.BaseData.Contracts.AppServices;
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
            return View();
        }
        public async Task<IActionResult> InsertColor()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> InsertColor()
        {

            return View();
        }


        public async Task<IActionResult> UpdateColor()
        {
            return View ();

        }
        [HttpPost]
        public async Task<IActionResult> UpdateColor(int id)
        {

            return View();
        }
        public async Task <IActionResult> RemoveColor(int id)
        {
            return View();
        }


    }
}
