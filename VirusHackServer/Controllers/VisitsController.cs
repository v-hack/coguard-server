﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using VirusHackServer.Managers;

namespace VirusHackServer.Controllers
{
    public class VisitsController : ApiController
    {
        // GET: Visits
        [HttpGet]
        public object Get(int user_id)
        {
            return ApiManager.ApiGetVisitsList(user_id); 
        }
        [HttpOptions]
        public HttpResponseMessage Options() {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}