using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CommunityCenterGorublyane.Core.Constants.AdministratorConstants;

namespace CommunityCenterGorublyane.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {
        
    }
}
