using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusHackServerLib.Models {
    public class ResearchModel {
        public ResearchModel() { }
        public ResearchModel(Research mdl, VirusHackServerEntities db) {
            this.ResearchId = mdl.ResearchId;
            this.Name = mdl.ResearchName;
            this.Result = mdl.ResearchResult;
            this.Date = mdl.Date; 
        }
        [JsonProperty("research_id")]
        public int ResearchId { get; set; }
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("result")]
        public string Result { get; set; }
    }
}
