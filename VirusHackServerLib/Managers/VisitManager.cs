using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusHackServerLib.Models;

namespace VirusHackServerLib.Managers {
    public static class VisitManager {
        public static List<VisitModel> GetVisitsList(int userId) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var result = new List<VisitModel>();
                    var user = db.UserProfile.FirstOrDefault(a => a.UserId == userId);
                    if (user == null)
                        return null;
                    var patient = user.Patient.FirstOrDefault();
                    if (patient == null)
                        return null;
                    if (patient.Visit == null)
                        return null;
                    patient.Visit.ToList().ForEach(visit => {
                        result.Add(new VisitModel(db, visit));
                    });
                    return result;
                }
            } catch(Exception ex) {
                return null;
            }
        }
    }
}
