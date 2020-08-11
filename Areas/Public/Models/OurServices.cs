using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDemoSite.Areas.Public.Models
{
    public class OurServices
    {
        public OurServices(siteDataDbContext context)
        {
            try
            {
                var ourServices = context.MpOurServices.Select(c => new OurServicesData()
                {
                    ServiceID = c.ServiceId,
                    ServiceName = c.ServiceName,
                    ServiceDescription = c.ServiceDescription,
                    ServiceImageLocation = context.PublicImages
                                            .Where(w => w.ImageId == c.ImageId)
                                            .Select(i => i.ImageLocation).FirstOrDefault()
                }).ToList();

                OurServicesData = ourServices;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<OurServicesData> OurServicesData { get; set; }
    }

    public class OurServicesData
    {
        public int ServiceID { get; set; }
        public string ServiceImageLocation { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
    }
}
