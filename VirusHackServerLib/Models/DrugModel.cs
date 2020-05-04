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

            var times = drug.TimetablePush?.ToList();
            if (times != null) {
                times.ForEach(time => {
                    this.Times.Add(time.Time.Value.TotalHours + "."
                        + time.Time.Value.TotalMinutes);
                });
            }

        }
        public int DrugId { get; set; }
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string DrugType { get; set; }
        public string FrequencyAdmission { get; set; }
        public string FeaturesReception { get; set; }
        public DateTime? StartReception { get; set; }
        public DateTime? FinishReception { get; set; }
        public List<string> Times { get; set; } = new List<string>();
    }
}
