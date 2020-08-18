using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class PageFooter
    {
        public PageFooter(siteDataDbContext context)
        {
            FooterText = context.PageFooter.Select(s => s.FooterText).SingleOrDefault();
            OpeningTimes1 = context.PageFooter.Select(s => s.OpeningTimes1).SingleOrDefault();
            OpeningTimes2 = context.PageFooter.Select(s => s.OpeningTimes2).SingleOrDefault();
            OpeningTimes3 = context.PageFooter.Select(s => s.OpeningTimes3).SingleOrDefault();
            OpeningTimes4 = context.PageFooter.Select(s => s.OpeningTimes4).SingleOrDefault();
            FaceBook = context.PageFooter.Select(s => s.FaceBook).SingleOrDefault();
            Instagram = context.PageFooter.Select(s => s.Instagram).SingleOrDefault();
            Twitter = context.PageFooter.Select(s => s.Twitter).SingleOrDefault();
            EmailAddress = context.PageFooter.Select(s => s.EmailAddress).SingleOrDefault();
            Address1 = context.PageFooter.Select(s => s.Address1).SingleOrDefault();
            Address2 = context.PageFooter.Select(s => s.Address2).SingleOrDefault();
            Address3 = context.PageFooter.Select(s => s.Address3).SingleOrDefault();
            Address4 = context.PageFooter.Select(s => s.Address4).SingleOrDefault();
            Address5 = context.PageFooter.Select(s => s.Address5).SingleOrDefault();
            int? IconImageId = context.PageFooter.Select(s => s.IconImageId).SingleOrDefault();

            IconImageLocation = context.PublicImages
                                    .Where(w => w.ImageId == IconImageId)
                                    .Select(s => s.ImageLocation).FirstOrDefault();

        }

        public string FooterText { get; set; }
        public string OpeningTimes1 { get; set; }
        public string OpeningTimes2 { get; set; }
        public string OpeningTimes3 { get; set; }
        public string OpeningTimes4 { get; set; }
        public string FaceBook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string EmailAddress { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Address5 { get; set; }
        public string IconImageLocation { get; set; }

    }
}
