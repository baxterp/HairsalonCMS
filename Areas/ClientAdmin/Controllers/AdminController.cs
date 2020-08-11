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
    [Authorize]
    public class AdminController : Controller
    {
        StartPageData pageData = null;

        public AdminController(StartPageData pageData)
        {
            this.pageData = pageData;
        }

        public IActionResult Index()
        {
            return View(pageData);
        }
    }
}
