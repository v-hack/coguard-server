using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusHackServerLib.Models {
    public class Doctor2PatientModel {
        public Doctor2PatientModel() { }
        public Doctor2PatientModel(VirusHackServerEntities db, Patient2Doctor mdl) {
            var patient = mdl.Patient;
            var patientProfile = patient?.UserProfile;
            var doctor = mdl.Doctor;
            if (patient == null || patientProfile == null)
                return;
            this.Diagnos = patient.Diagnosis;
            this.PatientFullName = patientProfile.FirstName + " "
                + patientProfile.SecondName + " "
                + patientProfile.LastName;
            this.PatientIndex = patient.PatientIndex ?? 0;
            var lastMeashure = patient.Measuring.OrderByDescending(a => a.Date).FirstOrDefault();
            if (lastMeashure == null)
                return;
            this.Temp = lastMeashure.Temp ?? 0;
            this.Pressure = lastMeashure.Pressure;
            this.Priority = doctor.Patient2Doctor?.FirstOrDefault(a => a.PatientId == patient.PatientId)?.Priority ?? 0;
        }

        [JsonProperty("patient_full_name")]
        public string PatientFullName { get; set; }
        [JsonProperty("patient_index")]
        public int PatientIndex { get; set; }
        [JsonProperty("diagnos")]
        public string Diagnos { get; set; }
        [JsonProperty("temp")]
        public float Temp { get; set; }
        [JsonProperty("pressure")]
        public string Pressure { get; set; }
        [JsonProperty("priority")]
        public int Priority { get; set; }
    }
}
