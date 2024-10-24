using CommunityCenterGorublyane.Core.Models.Gallery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class GalleryController : BaseController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new GalleryQueryModel();

            return View(model);
        }
    }
}
