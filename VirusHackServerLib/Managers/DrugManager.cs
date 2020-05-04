using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusHackServerLib.Enums;
using VirusHackServerLib.Models;

namespace VirusHackServerLib.Managers {
    public static class DrugManager {
        public static bool AddDrugForUser(int userId, 
            int doctorId, 
            string drugType,
            string frequencyAdmission,
            string featuresReception,
            string name,
            DateTime? startReception,
            DateTime? finishReception) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var userProfile = db.UserProfile.FirstOrDefault(a => a.UserId == userId);
                    var patient = userProfile?.Patient?.FirstOrDefault();
                    if (userProfile == null || patient == null)
                        return false;
                    var newDrug = new Drug() {
                        PatientId = patient.PatientId,
                        StartReception = startReception,
                        FinishReception = finishReception,
                        FrequencyAdmission = frequencyAdmission,
                        FeaturesReception = featuresReception,
                        DrugType = drugType,
                        Name = name
                    };
                    db.Drug.Add(newDrug);
                    db.SaveChanges();
                    return true;
                }
            } catch(Exception ex) {
                return false;
            }
        }
        public static List<DrugModel> GetDrugListForUser(int userId) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var result = new List<DrugModel>();
                    var userProfile = db.UserProfile.FirstOrDefault(a => a.UserId == userId);
                    var patient = userProfile?.Patient?.FirstOrDefault();
                    if (userProfile == null || patient == null)
                        return null;
                    var drugs = patient.Drug?.ToList();
                    if (drugs == null)
                        return null;
                    drugs.ForEach(drug => {
                        result.Add(new DrugModel(drug, db));
                    });

                    return result;
                }
            } catch(Exception ex) {
                return null;
            }
        }
    }
}
