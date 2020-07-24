using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HairDemoSite.Areas.Public.Controllers
{
    [Area("Public")]
    [AllowAnonymous]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Services")]
        public IActionResult Services()
        {
            return View();
        }
    }
}
