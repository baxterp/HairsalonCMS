using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HairDemoSite.Areas.Public.Models;

namespace HairDemoSite.Areas.Public.Controllers
{
    [Area("Public")]
    [AllowAnonymous]
    public class MainController : Controller
    {
        StartPageData startPageData = null;

        public MainController(StartPageData startPageData)
        {
            this.startPageData = startPageData;
        }

        public IActionResult Index()
        {
            return View(startPageData);
        }

        [Route("/Services")]
        public IActionResult Services()
        {
            return View();
        }
    }
}
