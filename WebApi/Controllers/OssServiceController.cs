using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class OssServiceController : ApiController
    {
        // GET: api/OssService
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OssService/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OssService
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OssService/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OssService/5
        public void Delete(int id)
        {
        }
    }
}
