using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VirusHackServer.Managers;

namespace VirusHackServer.Controllers {
    public class ApiTokenModel {

        public string token { get; set; }
    }
    public class TokenUpdateController : ApiController {
        [HttpGet]
        public object Get() {
            return ApiManager.SendPush();
        }
        // GET: TokenUpdate
        [HttpPost]
        public object Post(ApiTokenModel model) {
            return ApiManager.ApiUpdateToken(model.token);
        }

        [HttpOptions]
        public HttpResponseMessage Options() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}