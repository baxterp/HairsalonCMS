using System;
using System.Collections.Generic;

namespace HairDemoSite.Areas.Public.Data.SiteData
{
    public partial class PublicImages
    {
        public PublicImages()
        {
            MpCarousel = new HashSet<MpCarousel>();
            MpFlatPageData = new HashSet<MpFlatPageData>();
            MpOurServices = new HashSet<MpOurServices>();
        }

        public int ImageId { get; set; }
        public string ImageLocation { get; set; }
        public string ImageName { get; set; }
        public int? ImageWidth { get; set; }
        public int? ImageHeight { get; set; }

        public virtual ICollection<MpCarousel> MpCarousel { get; set; }
        public virtual ICollection<MpFlatPageData> MpFlatPageData { get; set; }
        public virtual ICollection<MpOurServices> MpOurServices { get; set; }
    }
}
