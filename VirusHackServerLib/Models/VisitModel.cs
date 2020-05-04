using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusHackServerLib.Models {
    public class VisitModel {
        public VisitModel() { }
        public VisitModel(VirusHackServerEntities db, Visit mdl) {
            this.Date = mdl.Date;
            this.PatientId = mdl.PatientId;
            this.DoctorId = mdl.DoctorId;
            var doctor = mdl.Doctor;
            if (doctor != null) {
                this.DoctorFullName = doctor.UserProfile.FirstName + " "
                    + doctor.UserProfile.SecondName + " "
                    + doctor.UserProfile.LastName;
                this.Specialization = doctor.Specialization;
            } 
        }
        [JsonProperty("date")]
        public DateTime? Date { get; set; }
        [JsonProperty("patient_id")]
        public int PatientId { get; set; }
        [JsonProperty("doctor_id")]
        public int DoctorId { get; set; }
        [JsonProperty("doctor_full_name")]
        public string DoctorFullName { get; set; }
        [JsonProperty("specialization")]
        public string Specialization { get; set; }
    }
}
