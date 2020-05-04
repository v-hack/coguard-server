using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusHackServerLib.Models {
    public class ObjectModel {
        public ObjectModel() { }
        public ObjectModel(VirusHackServerEntities db, Object mdl) {
            this.Name = mdl.Name;
            this.Link = mdl.Link;
        }
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
