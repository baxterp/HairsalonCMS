using System;
using System.Collections.Generic;

namespace HairDemoSite.Areas.Public.Data.SiteData
{
    public partial class PublicImages
    {
        public int ImageId { get; set; }
        public string ImageLocation { get; set; }
        public string ImageName { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }
    }
}
