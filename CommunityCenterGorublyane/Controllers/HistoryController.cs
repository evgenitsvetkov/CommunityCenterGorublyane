using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class HistoryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
