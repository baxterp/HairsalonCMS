using System;
using System.Collections.Generic;

namespace HairDemoSite.Areas.Public.Data.SiteData
{
    public partial class MpOurServices
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public int ImageId { get; set; }

        public virtual PublicImages Image { get; set; }
    }
}
