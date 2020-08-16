using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class StartPageFlatData
    {
        private siteDataDbContext context;

        public StartPageFlatData(siteDataDbContext context, IWebHostEnvironment hostingEnv)
        {
            this.context = context;

            try
            {
                if (hostingEnv.WebRootPath.Contains("Source2019"))
                    URLqualifier = string.Empty;
                else
                    URLqualifier = "haircms/";

                OurServicesMessage = context.MpFlatPageData.Select(s => s.OurServicesMessage).FirstOrDefault();
                PageTitle = context.MpFlatPageData.Select(s => s.PageTitle).FirstOrDefault();

                int? iconImageID = context.MpFlatPageData.Select(s => s.IconImageId).FirstOrDefault();
                IconImageLocation = URLqualifier + context.PublicImages
                                        .Where(images => images.ImageId == iconImageID)
                                        .Select(s => s.ImageLocation).FirstOrDefault();

                WelcomeMessage = context.MpFlatPageData.Select(s => s.WelcomeMessage).FirstOrDefault();
                PhoneNumber = context.MpFlatPageData.Select(s => s.PhoneNumber).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string OurServicesMessage { get; set; }
        public string PageTitle { get; set; }

        public string IconImageLocation { get; set; }
        public string WelcomeMessage { get; set; }
        public string PhoneNumber { get; set; }

        public string URLqualifier { get; set; }

    }
}
