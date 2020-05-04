using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusHackServerLib.Models;

namespace VirusHackServerLib.Managers {
    public static class UserManager {
        public static bool SetPressure() {
            return false;
        }

        public static bool SetTemp() {
            return false;
        }

        public static PatientModel MainPatientInfo(int userId) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var user = db.UserProfile.FirstOrDefault(a => a.UserId == userId);
                    if (user == null)
                        return null;
                    var result = new PatientModel(user, db);
                    return result;
                }
            } catch (Exception ex) {
                return null;
            }
        }

        public static DoctorModel MainDoctorInfo(int userId) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var user = db.UserProfile.FirstOrDefault(a => a.UserId == userId);
                    if (user == null)
                        return null;
                    var result = new DoctorModel(user, db);
                    return result;
                }
            } catch (Exception ex) {
                return null;
            }
        }
    }
}
