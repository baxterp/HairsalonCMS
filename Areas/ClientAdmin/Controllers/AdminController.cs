using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HairDemoSite.Areas.Public.Models;
using HairDemoSite.Areas.ClientAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http.Headers;
using System.IO;
using System.Drawing;
using System.Runtime.CompilerServices;
using HairDemoSite.Areas.Public.Data.SiteData;

namespace HairDemoSite.Areas.ClientAdmin.Controllers
{
    [Area("ClientAdmin")]
    [Authorize]
    public class AdminController : Controller
    {
        StartPageData pageData = null;
        SiteImageModel siteImages = null;
        private IWebHostEnvironment hostingEnv;
        siteDataDbContext context;

        public AdminController(siteDataDbContext context, StartPageData pageData, SiteImageModel siteImageModel, IWebHostEnvironment hostingEnv)
        {
            this.pageData = pageData;
            this.siteImages = siteImageModel;
            this.hostingEnv = hostingEnv;
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(pageData);
        }

        public IActionResult Images()
        {
            return View(siteImages);
        }

        [HttpPost]
        public async Task<IActionResult> FileUpload()
        {
            try
            {
                var fileData = Request.Form.Files;

                foreach (IFormFile file in fileData)
                {
                    string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                    filename = this.EnsureCorrectFilename(filename);

                    var filePath = this.GetPathAndFilename(filename);

                    using (FileStream output = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(output);
                    }

                    Image img = Image.FromFile(filePath);

                    var width = img.Width;
                    var height = img.Height;

                    var dataToSave = new PublicImages
                    {
                        ImageName = filename,
                        ImageHeight = height,
                        ImageWidth = width,
                        ImageLocation = filePath.Replace(this.hostingEnv.WebRootPath + @"\", string.Empty).Replace(@"\", @"/")
                    };

                    context.PublicImages.Add(dataToSave);
                    context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            var imageLocation = this.hostingEnv.WebRootPath + @"\public\img\saved\" + filename;

            return imageLocation;
        }
    }
}
