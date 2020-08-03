using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HairDemoSite.Areas.ClientAdmin.Controllers
{
    [Area("ClientAdmin")]
    [Authorize(Roles = "Admin")]
    //[AllowAnonymous]
    public class UserController : Controller
    {
        [Route("ClientAdmin/CreateUser")]
        public IActionResult Index()
        {
            return RedirectToRoute("Identity");
            //return View();
        }
    }
}
