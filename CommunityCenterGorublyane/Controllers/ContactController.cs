using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class ContactController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
