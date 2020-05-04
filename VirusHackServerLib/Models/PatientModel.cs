using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusHackServerLib.Models {
    public class PatientModel {
        public PatientModel() { }
        public PatientModel(UserProfile mdl, VirusHackServerEntities db) {
            DateTime zeroTime = new DateTime(1, 1, 1);

            this.UserId = mdl.UserId;
            this.FirstName = mdl.FirstName;
            this.Patronymic = mdl.SecondName;
            this.LastName = mdl.LastName;
            var patient = mdl.Patient.FirstOrDefault();
            if (patient == null) return;
            this.Gender = patient.Gender;

            if (patient.BirthDate != null) {
                var span = DateTime.Now.Subtract((DateTime)patient.BirthDate);
                this.Age = (zeroTime + span).Year - 1;
            }

            this.City = patient.City;
            this.Diagnosis = patient.Diagnosis;
            this.Features = patient.Features;
            this.ReceiptDate = patient.ReceiptDate;
            this.LaboratoryData = mdl.LaboratoryData;
            this.AllergiesList = new List<string>();
            this.PatientIndex = patient.PatientIndex ?? 0;
            if (mdl.Allergy2User!= null && mdl.Allergy2User.Count > 0) {
                this.AllergiesList = mdl.Allergy2User.Select(a => a.DragName).ToList();
            }
            if (mdl.Research != null 
                && mdl.Research.Count > 0) {
                this.ResearchsList = new List<ResearchModel>();
                mdl.Research.ToList().ForEach(research => {
                    this.ResearchsList.Add(new ResearchModel(research, db));
                });
            }
        }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("gender")]
        public int? Gender { get; set; }
        [JsonProperty("age")]
        public int? Age { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("receipt_date")]
        public DateTime? ReceiptDate { get; set; }
        [JsonProperty("diagnosis")]
        public string Diagnosis { get; set; }
        [JsonProperty("laboratory_data")]
        public string LaboratoryData { get; set; }
        [JsonProperty("features")]
        public string Features { get; set; }
        [JsonProperty("allergies_list")]
        public List<string> AllergiesList { get; set; }
        [JsonProperty("researchs_list")]
        public List<ResearchModel> ResearchsList { get; set; }
        [JsonProperty("patient_index")]
        public int PatientIndex { get; set; }
    }
}
