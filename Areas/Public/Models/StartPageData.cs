using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageData
    {
        public StartPageData()
        {
            HeaderCarousel = new Carousel();
        }

        public Carousel HeaderCarousel { get; set; }
    }

    public class Carousel
    {
        public Carousel()
        {
            Tiles = new List<CarouselData> {
                                                new CarouselData { TileImageLocation = "public/img/bg-img/16.jpg", TileMessage = "“Discover your own style. Don't try to repeat what has already been written - have the courage to do your own thing and don't be afraid to do something different.”", TileTitle = "We Care About Your Hair" },
                                                new CarouselData { TileImageLocation = "public/img/bg-img/17.jpg", TileMessage = "“Discover your own style. Don't try to repeat what has already been written - have the courage to do your own thing and don't be afraid to do something different.”", TileTitle = "We Care About Your Hair" }
                                            };
        }

        public List<CarouselData> Tiles { get; set; }
    }

    public class CarouselData
    {
        public string TileImageLocation { get; set; }
        public string TileTitle { get; set; }
        public string TileMessage { get; set; }
    }
}
