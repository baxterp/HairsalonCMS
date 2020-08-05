using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageData
    {
        public StartPageData(siteDataDbContext context, Carousel headerCarousel, StartPageFlatData startPageFlatData, ImageDBCreator imageDBCreator)
        {
            HeaderCarousel = headerCarousel;
            StartPageFlatData = startPageFlatData;

            //imageDBCreator.CreateUpdateImagesData();

            PublicImages = context.PublicImages.ToList();
        }

        public Carousel HeaderCarousel { get; set; }
        public StartPageFlatData StartPageFlatData { get; set; }
        public List<PublicImages> PublicImages { get; set; }
    }
}
