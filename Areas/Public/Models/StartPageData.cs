using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageData
    {
        public StartPageData(Carousel headerCarousel, StartPageFlatData startPageFlatData)
        {
            HeaderCarousel = headerCarousel;
            StartPageFlatData = startPageFlatData;
        }

        public Carousel HeaderCarousel { get; set; }
        public StartPageFlatData StartPageFlatData { get; set; }
    }
}
