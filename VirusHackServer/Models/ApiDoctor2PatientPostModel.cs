using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirusHackServer.Models {
    public class ApiDoctor2PatientPostModel {
        public int doctor_id { get; set; }
        public int user_id { get; set; }
        public int priority { get; set; }
    }
}