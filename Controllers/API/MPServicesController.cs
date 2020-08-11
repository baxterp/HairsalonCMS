using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Mvc;

namespace HairDemoSite.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MPServicesController : ControllerBase
    {
        private siteDataDbContext context;

        public MPServicesController(siteDataDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [ActionName("CreateNewService")]
        public void CreateNewService(NewServiceDTO dto)
        {
            try
            {
                int imageID = context.PublicImages
                                        .Where(w => w.ImageLocation == dto.ImageLocation)
                                        .Select(s2 => s2.ImageId).FirstOrDefault();

                MpOurServices newService = new MpOurServices { ImageId = imageID, ServiceName = dto.ServiceTitle, ServiceDescription = dto.ServiceDescription };

                context.MpOurServices.Add(newService);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("DeleteService")]
        public void DeleteService(RequestData data)
        {
            try
            {
                bool gotIntValue = int.TryParse(data.idString, out int id);

                if (gotIntValue && id > 0)
                {
                    var entrytoDelete = context.MpOurServices.Select(s => s).Where(w => w.ServiceId == id).FirstOrDefault();

                    if (entrytoDelete != null)
                    {
                        context.MpOurServices.Remove(entrytoDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }

    public class NewServiceDTO
    {
        public string ImageLocation { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
    }

}
