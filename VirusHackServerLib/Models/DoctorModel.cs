using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusHackServerLib.Enums;

namespace VirusHackServerLib.Models {
    public class DoctorModel {
        public DoctorModel() { }
        public DoctorModel(UserProfile mdl, VirusHackServerEntities db) {
            //   this.DoctorId
            this.UserId = mdl.UserId;
            this.FirstName = mdl.FirstName;
            this.Patronymic = mdl.SecondName;
            this.LastName = mdl.LastName;
            var doctor = mdl.Doctor.FirstOrDefault();
            if (doctor == null)
                return;
            this.DoctorId = doctor.DoctorId;
            this.Specialization = doctor.Specialization;
            this.Rating = doctor.Rating ?? 0;
            this.UrlYouTube = doctor.UrlYouTube;
            this.Docs = new List<ObjectModel>();
            if (mdl.Object != null 
                && mdl.Object.Any(a=>a.ObjectType == (int)ObjectTypesEnum.Docs)) {
                mdl.Object
                    .Where(a => a.ObjectType == (int)ObjectTypesEnum.Docs)
                    .ToList()
                    .ForEach(obj => {
                        this.Docs.Add(new ObjectModel(db, obj));
                    });
            }
            this.Description = doctor.Description;
            this.Approved = doctor.Approved ?? false;
        }
        [JsonProperty("doctor_id")]
        public int DoctorId { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("specialization")]
        public string Specialization { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url_youtube")]
        public string UrlYouTube { get; set; }
        [JsonProperty("rating")]
        public int Rating { get; set; }
        [JsonProperty("docs")]
        public List<ObjectModel> Docs { get; set; }
        [JsonProperty("approved")]
        public bool Approved { get; set; }
    }
}
