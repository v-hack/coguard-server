using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VirusHackServer.Models;

namespace VirusHackServer.Controllers {
    public class MeasuringController : ApiController {
        // GET: Measuring
        [HttpPost]
        public object Post(ApiMeasuringPostModel model) {
            return null;
        }

        [HttpPut]
        public object Put(ApiMeasurinPutModel model) {
            return null;
        }

        [HttpOptions]
        public HttpResponseMessage Options() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}