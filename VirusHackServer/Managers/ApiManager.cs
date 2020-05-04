using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirusHackServerLib.Enums;
using VirusHackServerLib.Managers;
using VirusHackServerLib.Models;

namespace VirusHackServer.Managers {
    public static class ApiManager {

        public static DoctorModel ApiGetMainDoctorInfo(int userId) {
          
            return UserManager.MainDoctorInfo((int)userId);
        }

        public static PatientModel ApiGetMainPatientInfo(int userId) {
            return UserManager.MainPatientInfo((int)userId);
        }

        public static List<VisitModel> ApiGetVisitsList(int userId) {
            return VisitManager.GetVisitsList(userId);
        }

        public static List<Doctor2PatientModel> ApiGetPatientsForDoctor(int doctorId) {
            return Doctor2PatientManager.GetPatientsList(doctorId);
        }

        public static bool ApiSetPatientPriority(int doctorId, int userId, int priority) {
            return Doctor2PatientManager.ChangePatientPriority(doctorId, userId, priority);
        }
    }
}