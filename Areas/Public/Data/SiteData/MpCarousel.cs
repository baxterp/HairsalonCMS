using System;
using System.Collections.Generic;

namespace HairDemoSite.Areas.Public.Data.SiteData
{
    public partial class MpCarousel
    {
        public int TileId { get; set; }
        public string TileTitle { get; set; }
        public string TileMessage { get; set; }
        public int? ImageId { get; set; }

        public virtual PublicImages Image { get; set; }
    }
}
