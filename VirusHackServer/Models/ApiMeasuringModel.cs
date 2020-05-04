using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirusHackServer.Models {
    public class ApiMeasuringPostModel {
        public int user_id { get; set; }
        public float temp { get; set; }
    }

    public class ApiMeasurinPutModel {
        public int user_id { get; set; }
        public string pressure { get; set; }
    }
}