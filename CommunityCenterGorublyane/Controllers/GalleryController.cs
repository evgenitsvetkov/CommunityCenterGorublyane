using CommunityCenterGorublyane.Core.Models.Gallery;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class GalleryController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new GalleryQueryModel();

            return View(model);
        }
    }
}
