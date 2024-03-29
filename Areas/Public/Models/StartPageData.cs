﻿using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageData
    {
        public StartPageData(siteDataDbContext context, Carousel headerCarousel, StartPageFlatData startPageFlatData, 
                             OurServices ourServices, ImageDBCreator imageDBCreator, IWebHostEnvironment hostingEnv, IHttpContextAccessor httpContextAccessor)
        {
            //var url = RequestCo  Context.Request.Url.AbsoluteUri;

            //var url = httpContextAccessor.HttpContext.Request.Host.Value;

            HeaderCarousel = headerCarousel;
            StartPageFlatData = startPageFlatData;
            OurServicesData = ourServices;

            if (hostingEnv.WebRootPath.Contains("Source2019"))
                BackgroundImageStart = string.Empty;
            else
                BackgroundImageStart = "haircms/";

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
