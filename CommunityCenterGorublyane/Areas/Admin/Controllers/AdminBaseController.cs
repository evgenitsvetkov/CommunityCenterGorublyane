using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CommunityCenterGorublyane.Core.Constants.RoleConstants;

namespace CommunityCenterGorublyane.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
