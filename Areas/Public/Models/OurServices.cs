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
                var ourServices = context.MpOurServices.Select(service => new OurServicesData()
                {
                    ServiceID = service.ServiceId,
                    ServiceName = service.ServiceName,
                    ServiceDescription = service.ServiceDescription,
                    ServiceImageLocation = context.PublicImages
                                            .Where(images => images.ImageId == service.ImageId)
                                            .Select(img => img.ImageLocation).FirstOrDefault()
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
