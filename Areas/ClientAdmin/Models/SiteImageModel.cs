using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.ClientAdmin.Models
{
    public class SiteImageModel
    {
        public SiteImageModel(siteDataDbContext context, IWebHostEnvironment hostingEnv)
        {
            //if (hostingEnv.WebRootPath.Contains("Source2019"))
            //    URLqualifier = string.Empty;
            //else
            //    URLqualifier = string.Empty;

            var siteImages = context.PublicImages.Select(img => new ImagesData()
            {
                ImagesID = img.ImageId,
                ImageName = img.ImageName,
                ImageLocation = img.ImageLocation
            });

            Images = siteImages.OrderByDescending(d => d.ImagesID).ToList();
        }

        public List<ImagesData> Images { get; set; }
        public string URLqualifier { get; set; }
    }

    public class ImagesData
    {
        public int ImagesID { get; set; }
        public string ImageLocation { get; set; }
        public string ImageName { get; set; }
    }
}
