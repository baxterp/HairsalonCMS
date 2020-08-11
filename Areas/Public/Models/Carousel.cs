using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class Carousel
    {
        public Carousel(siteDataDbContext context)
        {
            try
            {
                var carouselData = context.MpCarousel.Select(c => new CarouselData()
                {
                    TileID = c.TileId,
                    TileTitle = c.TileTitle,
                    TileMessage = c.TileMessage,
                    TileImageLocation = context.PublicImages
                                            .Where(w => w.ImageId == c.ImageId)
                                            .Select(s => s.ImageLocation).FirstOrDefault()
                });

                Tiles = carouselData.ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<CarouselData> Tiles { get; set; }
    }

    public class CarouselData
    {
        public int TileID { get; set; }
        public string TileImageLocation { get; set; }
        public string TileTitle { get; set; }
        public string TileMessage { get; set; }
    }
}
