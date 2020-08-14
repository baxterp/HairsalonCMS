using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageData
    {
        public StartPageData(siteDataDbContext context, Carousel headerCarousel, StartPageFlatData startPageFlatData, 
                             OurServices ourServices, ImageDBCreator imageDBCreator, IWebHostEnvironment hostingEnv)
        {
            HeaderCarousel = headerCarousel;
            StartPageFlatData = startPageFlatData;
            OurServicesData = ourServices;

            //if (hostingEnv.WebRootPath.Contains("Source2019"))
            //    BackgroundImageStart = string.Empty;
            //else
            //    BackgroundImageStart = string.Empty;

            //imageDBCreator.CreateUpdateImagesData();

            PublicImages = context.PublicImages.ToList();
        }

        public string BackgroundImageStart { get; set; }

        public Carousel HeaderCarousel { get; set; }
        public StartPageFlatData StartPageFlatData { get; set; }
        public List<PublicImages> PublicImages { get; set; }
        public OurServices OurServicesData { get; set; }
    }
}
