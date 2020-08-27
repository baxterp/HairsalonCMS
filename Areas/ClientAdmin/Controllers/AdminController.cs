using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HairDemoSite.Areas.Public.Models;
using HairDemoSite.Areas.ClientAdmin.Models;
using Microsoft.AspNetCore.Hosting;
using HairDemoSite.Areas.Public.Data.SiteData;

namespace HairDemoSite.Areas.ClientAdmin.Controllers
{
    [Area("ClientAdmin")]
    [Authorize]
    public class AdminController : Controller
    {
        StartPageData pageData = null;
        SiteImageModel siteImages = null;

        public AdminController(StartPageData pageData, SiteImageModel siteImageModel)
        {
            this.pageData = pageData;
            this.siteImages = siteImageModel;
        }

        public IActionResult Index()
        {
            return View(pageData);
        }

        public IActionResult Images()
        {
            return View(siteImages);
        }
    }
}
