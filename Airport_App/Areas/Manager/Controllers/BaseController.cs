using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airport_App.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Route("/Manager/[controller]/[Action]/{id?}")]
    [Authorize(Policy = "AdminsOnly")]
    public class BaseController : Controller
    {
        
    }
}
