using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CommunityCenterGorublyane.Core.Constants.AdministratorConstants;

namespace CommunityCenterGorublyane.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {
        
    }
}
