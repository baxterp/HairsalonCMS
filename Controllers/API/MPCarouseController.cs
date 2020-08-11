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
    public class MPCarouselController : ControllerBase
    {
        private siteDataDbContext context;

        public MPCarouselController(siteDataDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [ActionName("CreateNewTile")]
        public void CreateNewTile(NewTileDTO dto)
        {
            try
            {
                int imageID = context.PublicImages
                                        .Where(w => w.ImageLocation == dto.ImageLocation)
                                        .Select(s2 => s2.ImageId).FirstOrDefault();

                MpCarousel newCarouselTile = new MpCarousel { ImageId = imageID, TileMessage = dto.TileMessage, TileTitle = dto.TileTitle };

                context.MpCarousel.Add(newCarouselTile);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("DeleteTile")]
        public void DeleteTile(RequestData data)
        {
            try
            {
                bool gotIntValue = int.TryParse(data.idString, out int id);

                if (gotIntValue && id > 0)
                {
                    var entrytoDelete = context.MpCarousel.Select(s => s).Where(w => w.TileId == id).FirstOrDefault();

                    if (entrytoDelete != null)
                    {
                        context.MpCarousel.Remove(entrytoDelete);
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

    public class NewTileDTO
    {
        public string ImageLocation { get; set; }
        public string TileTitle { get; set; }
        public string TileMessage { get; set; }
    }

    public class RequestData
    {
        public string idString { get; set; }
    }
}
