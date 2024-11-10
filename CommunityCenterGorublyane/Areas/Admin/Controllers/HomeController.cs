using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
