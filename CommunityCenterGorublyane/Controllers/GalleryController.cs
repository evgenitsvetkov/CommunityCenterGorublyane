using CommunityCenterGorublyane.Core.Models.Gallery;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class GalleryController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new GalleryQueryModel();

            return View(model);
        }
    }
}
