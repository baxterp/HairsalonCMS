using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ActionName("CreateNewTile")]
        public void CreateNewTile(NewTileDTO dto)
        {
        }

        [HttpPost]
        [ActionName("DeleteTile")]
        public void DeleteTile(DeleteData data)
        {
            int id = 0;
            bool gotIntValue = int.TryParse(data.idString, out id);

            if (gotIntValue && id > 0)
            {
                var entrytoDelete = context.MpCarousel.Select(s => s).Where(w => w.TileId == id).FirstOrDefault();

                if(entrytoDelete != null)
                {
                    context.MpCarousel.Remove(entrytoDelete);
                    context.SaveChanges();
                }
            }
        }
    }

    public class NewTileDTO
    {
        public string ImageLocation { get; set; }
        public string TileTitle { get; set; }
        public string TileMessage { get; set; }
    }

    public class DeleteData
    {
        public string idString { get; set; }
    }
}
