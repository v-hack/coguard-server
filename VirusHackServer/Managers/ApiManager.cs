using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using VirusHackServer.Controllers;
using VirusHackServerLib;
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

        public static List<DrugModel> ApiGetDrugListForUser(int userId) {
            return DrugManager.GetDrugListForUser(userId);
        }

        public static bool ApiCreateNewDrugForUser(ApiDrugPost model) {
            return DrugManager.AddDrugForUser(model.user_id,
                model.doctor_id,
                model.drug_type,
                model.frequency_admission,
                model.features_reception,
                model.name,
                model.start_reception,
                model.finish_reception);
        }

        public static bool SendPush() {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var token = db.TokenPush.FirstOrDefault(a => a.IsActive);
                    if (token == null)
                        return false;

                    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                    var json = serializer.Serialize(new {
                        to = token.Token,
                        collapse_key = "type_a",
                        notification = new {
                            body = "Будьте здоровы!",
                            title = "Доктор в кармане"
                        }
                    });

                    var request = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                    var data = Encoding.ASCII.GetBytes(json);

                    request.Method = "POST";

                    request.ContentType = "application/json";
                    request.Headers.Add("Authorization", "key=AAAAhVEl7LI:APA91bGq1JbO1-IYWf-YDzI9plrJeRB7a6xwDw0ausbSdhZBASIdIggP-UK3kn8bKLtp5E836l_GvKd_32ngyzhWCBwc3C-XmzlpeG6lkT4l9MDHrqgsHtPFrzQEhzZpXXIVGOPn3Qce");

                    request.Accept = "application/json";

                    request.ContentLength = data.Length;

                    using (var stream = request.GetRequestStream()) {
                        stream.Write(data, 0, data.Length);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) {
                        var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                        response.Close();
                    }

                    return true;
                }
            } catch (Exception ex) {
                return false;
            }
            return false;
        }

        public static bool ApiUpdateToken(string token) {
            try {
                using (var db = new VirusHackServerEntities()) {
                    var tokens = db.TokenPush.ToList();
                    tokens.ForEach(a => {
                        a.IsActive = false;
                    });
                    var newToken = new TokenPush() {
                        Token = token,
                        Date = DateTime.Now,
                        IsActive = true
                    };
                    db.TokenPush.Add(newToken);
                    db.SaveChanges();
                    return true;
                }
            } catch (Exception ex) {
                return false;
            }
        }
    }
}