using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HairDemoSite.Areas.Public.Models;

namespace HairDemoSite.Areas.ClientAdmin.Controllers
{
    [Area("ClientAdmin")]
    //[Authorize]
    public class AdminController : Controller
    {
        StartPageData pageData = null;
        public IActionResult Index()
        {
            pageData = new StartPageData();
            return View(pageData);
        }
    }
}
