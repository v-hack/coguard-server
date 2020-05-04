using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirusHackServer.Models {
    public class AuthModel {
        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("login")]
        public string Login { get; set; }
        [JsonProperty("role")]
        public int Role { get; set; }
    }
}