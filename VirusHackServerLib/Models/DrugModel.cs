using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusHackServerLib.Enums;

namespace VirusHackServerLib.Models {
    public class DrugModel {
        public DrugModel() { }
        public DrugModel(Drug drug, VirusHackServerEntities db) {
            this.DrugId = drug.DrugId;
            this.PatientId = drug.PatientId;
            this.Name = drug.Name;

            this.FrequencyAdmission = drug.FrequencyAdmission;
            this.FeaturesReception = drug.FeaturesReception;
            this.DrugType = drug.DrugType;
            
            this.StartReception = drug.StartReception;
            this.FinishReception = drug.FinishReception;
            this.period = drug.Period ?? 0;

            drug.TimetablePush?.ToList()?.ForEach(a => {
                this
                .times
                .Add(a.Time.HasValue ? (a.Time.Value.Hours + "." + a.Time.Value.Minutes) : "");
            });
        }
        public int DrugId { get; set; }
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string DrugType { get; set; }
        public string FrequencyAdmission { get; set; }
        public string FeaturesReception { get; set; }
        public DateTime? StartReception { get; set; }
        public DateTime? FinishReception { get; set; }
        public bool Allowed { get; set; } = true;
        public int period { get; set; } = 0;
        public List<string> times { get; set; } = new List<string>();
    }
}
