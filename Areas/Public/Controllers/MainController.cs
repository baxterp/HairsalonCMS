using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HairDemoSite.Areas.Public.Models;
using Microsoft.Extensions.Logging;

namespace HairDemoSite.Areas.Public.Controllers
{
    [Area("Public")]
    [AllowAnonymous]
    public class MainController : Controller
    {
        private ILogger logger;
        private StartPageData startPageData = null;

        public MainController(StartPageData startPageData, ILogger<MainController> logger)
        {
            this.startPageData = startPageData;
            this.logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                return View(startPageData);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }

        [Route("/Services")]
        public IActionResult Services()
        {
            return View();
        }
    }
}
