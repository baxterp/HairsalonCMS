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
    public class MPServicesController : ControllerBase
    {
        private siteDataDbContext context;

        public MPServicesController(siteDataDbContext context)
        {
            this.context = context;
        }

        // GET: api/<MPServicesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MPServicesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MPServicesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MPServicesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MPServicesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
