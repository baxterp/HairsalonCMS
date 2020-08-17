using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairDemoSite.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MPFlatDataController : ControllerBase
    {
        private siteDataDbContext context;

        public MPFlatDataController(siteDataDbContext context)
        {
            this.context = context;
        }


        [HttpPost]
        [ActionName("SaveFlatData")]
        public void SaveFlatData(FlatDataDTO dto)
        {
            try
            {
                int imageID = context.PublicImages
                                        .Where(w => w.ImageLocation == dto.IconImage)
                                        .Select(s => s.ImageId).FirstOrDefault();

                var flatData = context.MpFlatPageData.FirstOrDefault();

                flatData.WelcomeMessage = dto.WelcomeMessage;
                flatData.PhoneNumber = dto.PhoneNumber;
                flatData.IconImageId = imageID;

                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    public class FlatDataDTO
    {
        public string IconImage { get; set; }
        public string WelcomeMessage { get; set; }
        public string PhoneNumber { get; set; }
    }

}
