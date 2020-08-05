using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageData
    {
        public StartPageData(siteDataDbContext context)
        {
            HeaderCarousel = new Carousel(context);
        }

        public Carousel HeaderCarousel { get; set; }
    }
}
