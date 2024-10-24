using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
