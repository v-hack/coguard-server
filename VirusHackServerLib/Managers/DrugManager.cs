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
            int period,
            List<string> times) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var userProfile = db.UserProfile.FirstOrDefault(a => a.UserId == userId);
                    var patient = userProfile?.Patient?.FirstOrDefault();
                    if (userProfile == null || patient == null)
                        return false;
                    var newDrug = new Drug() {
                        PatientId = patient.PatientId,
                        StartReception = DateTime.Now,
                        FinishReception = DateTime.Now.AddMonths(period),
                        FrequencyAdmission = frequencyAdmission,
                        FeaturesReception = featuresReception,
                        DrugType = drugType,
                        Name = name, 
                        Period = period
                    };
                    db.Drug.Add(newDrug);

                    times.ForEach(time => {
                        TimeSpan interval;
                        if (TimeSpan.TryParseExact(time, @"hh\:mm", null, out interval))
                          
                        db.TimetablePush.Add(new TimetablePush() {
                            Time = interval,
                            DrugId = newDrug.DrugId
                        });

                    });
                    db.SaveChanges();

                    return true;
                }
            } catch (Exception ex) {
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

                    var dangerousCombinations = db.DangerousDrugCombination.ToList();
                    foreach (var elem in result) {
                        var found = dangerousCombinations
                            .Where(a => a.FirstDrugName.Trim().ToLower() == elem.Name.Trim().ToLower() ||
                        a.SecondDrugName.Trim().ToLower() == elem.Name.Trim().ToLower())
                        .ToList();
                        if (!found.Any())
                            continue;
                        foreach (var foundElem in found) {
                            if (foundElem.FirstDrugName.Trim().ToLower() == elem.Name.Trim().ToLower()) {
                                if (result
                                    .Any(a => a.Name.Trim().ToLower()
                                    == foundElem.SecondDrugName.Trim().ToLower()))
                                    elem.Allowed = false;

                            }
                        }

                        foreach (var foundElem in found) {
                            if (foundElem.SecondDrugName.Trim().ToLower() == elem.Name.Trim().ToLower()) {
                                if (result
                                    .Any(a => a.Name.Trim().ToLower()
                                    == foundElem.FirstDrugName.Trim().ToLower()))
                                    elem.Allowed = false;
                            }
                        }
                    }

                    return result;
                }
            } catch (Exception ex) {
                return null;
            }
        }
    }
}
