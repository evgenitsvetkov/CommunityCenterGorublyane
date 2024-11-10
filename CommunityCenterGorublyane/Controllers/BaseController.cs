using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CommunityCenterGorublyane.Core.Constants.RoleConstants;

namespace CommunityCenterGorublyane.Controllers
{
    [Authorize(Roles = AdminRole)]
    public class BaseController : Controller
    {
        
    }
}
