using System;
using System.Collections.Generic;

namespace HairDemoSite.Areas.Public.Data.SiteData
{
    public partial class MpFlatPageData
    {
        public int Id { get; set; }
        public string WelcomeMessage { get; set; }
        public string PhoneNumber { get; set; }
        public string OurServicesMessage { get; set; }
        public string PageTitle { get; set; }
        public int? IconImageId { get; set; }

        public virtual PublicImages IconImage { get; set; }
    }
}
