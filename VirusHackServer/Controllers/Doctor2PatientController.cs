using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VirusHackServer.Managers;
using VirusHackServer.Models;

namespace VirusHackServer.Controllers {
    public class Doctor2PatientController : ApiController {
        // GET: Doctor2Patient
        [HttpGet]
        public object Get(int user_id) {
            return ApiManager.ApiGetPatientsForDoctor(user_id);
        }

        [HttpPost]
        public object Post(ApiDoctor2PatientPostModel model) {
            return ApiManager.ApiSetPatientPriority(model.doctor_id, model.user_id, model.priority);
        }

        [HttpOptions]
        public HttpResponseMessage Options() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}