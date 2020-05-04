using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirusHackServerLib.Models;

namespace VirusHackServerLib.Managers {
    public static class Doctor2PatientManager {
        public static List<Doctor2PatientModel> GetPatientsList(int doctorId) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var result = new List<Doctor2PatientModel>();
                    var doctorProfile = db.UserProfile.FirstOrDefault(a => a.UserId == doctorId);
                    if (doctorProfile == null || doctorProfile.Doctor == null)
                        return null;
                    var doctor = doctorProfile.Doctor.FirstOrDefault();
                    if (doctor.Patient2Doctor == null)
                        return result;

                    doctor.Patient2Doctor.ToList().ForEach(a => {
                        result.Add(new Doctor2PatientModel(db, a));
                    });

                    result = result.OrderByDescending(a => a.Priority).ToList();

                    return result;
                }
            } catch(Exception ex) {
                return null;
            }
        }

        public static bool ChangePatientPriority(int doctorId, int userId, int priority) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var doctorProfile = db.UserProfile.FirstOrDefault(a => a.UserId == doctorId);
                    if (doctorProfile == null || doctorProfile.Doctor == null)
                        return false;
                    var doctor = doctorProfile.Doctor.FirstOrDefault();
                    if (doctor.Patient2Doctor == null)
                        return false;
                    var usr = doctor.Patient2Doctor.FirstOrDefault(a => a.Patient.UserId == userId);
                    if (usr == null)
                        return false;
                    usr.Priority = priority;
                    db.SaveChanges();
                    return true;
                }
            } catch(Exception ex) {
                return false;
            }
            return false;
        }
    }
}
