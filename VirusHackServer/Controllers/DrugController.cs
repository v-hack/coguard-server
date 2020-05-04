using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VirusHackServer.Managers;

namespace VirusHackServer.Controllers {
    public class ApiDrugPost {
        public int user_id { get; set; }
        public int doctor_id { get; set; }
        public string drug_type { get; set; }
        public string name { get; set; }
        public string frequency_admission { get; set; }
        public string features_reception { get; set; }
        public int period { get; set; }
        public List<string> time { get; set; }
    }

    public class DrugController : ApiController {
        // GET: Measuring
        [HttpPost]
        public object Post(ApiDrugPost model) {
            return ApiManager.ApiCreateNewDrugForUser(model);
        }

        [HttpGet]
        public object Get(int user_id) {
            return ApiManager.ApiGetDrugListForUser(user_id);
        }

        [HttpOptions]
        public HttpResponseMessage Options() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}