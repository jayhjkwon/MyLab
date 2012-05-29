using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BackboneAspMvcTest.Controllers
{
    public class ApiController : Controller
    {
        private List<Patient> patients = MakeTestData();

        [HttpGet]
        [ActionName("Patients")]
        public JsonResult GetAllPatients(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Json(null, JsonRequestBehavior.AllowGet);
            else
                return Json(patients.FindAll(p => p.FirstName.ToUpper().Contains(name.ToUpper()) || p.LastName.ToUpper().Contains(name.ToUpper())), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("PatientById")]
        public JsonResult GetPatientById(string id)
        {
            return Json(patients.SingleOrDefault(p => p.ID == id), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("PatientsByName")]
        public JsonResult GetPatientByName(string name)
        {
            return Json(patients.FindAll(p => p.FirstName.ToUpper().Contains(name.ToUpper()) || p.LastName.ToUpper().Contains(name.ToUpper())), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ActionName("Patients")]
        public JsonResult AddPatient(Patient patient)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        [ActionName("Patients")]
        public JsonResult UpdatePatient(Patient patient)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        [ActionName("Patients")]
        public JsonResult DeletePatient(int id)
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }

        private static List<Patient> MakeTestData()
        {
            List<Patient> returnValues = new List<Patient>();
            string[] ids = {
                               "100^^^&2.16.840.1.113883.3.37.4.1.1.2.1.1&ISO",
                               "200^^^&2.16.840.1.113883.3.37.4.1.1.2.1.1&ISO",
                               "300^^^&2.16.840.1.113883.3.37.4.1.1.2.1.1&ISO",
                               "400^^^&2.16.840.1.113883.3.37.4.1.1.2.1.1&ISO",
                               "500^^^&2.16.840.1.113883.3.37.4.1.1.2.1.1&ISO",
                               "600^^^&2.16.840.1.113883.3.37.4.1.1.2.1.1&ISO"
                           };
            string[] lastName = {
                                    @"Kwon",
                                    @"Lee",
                                    @"Lim",
                                    @"Son",
                                    @"Cho",
                                    @"Chung"
                                };
            string[] firstName = {
                                     @"Hyojung",
                                     @"Reeyan",
                                     @"Chul",
                                     @"Kyoungjoo",
                                     @"Eunhye",
                                     @"Hyejung"
                                 };
            string[] gender = {
                                  "M",
                                  "M",
                                  "M",
                                  "M",
                                  "F",
                                  "F"
                              };

            for (int i = 0; i < ids.Length; i++)
            {
                returnValues.Add(
                    new Patient()
                    {
                        ID = ids[i],
                        LastName = lastName[i],
                        FirstName = firstName[i],
                        DateOfBirth = "19900101",
                        Address = GetAddress("1026 Montgomery Street^^Norristown^PA^19401^USA^^^CHITTENDEN"),
                        Gender = gender[i],
                        HomePhone = "(032)717-1234"
                    });
            }

            return returnValues;
        }

        private static string GetAddress(string add)
        {
            string address = string.Empty;
            string[] adds = add.Split(new char[] { '^' });
            string returnValue = string.Empty;
            foreach (string s in adds)
            {
                if (string.IsNullOrEmpty(s))
                    continue;

                returnValue += string.IsNullOrEmpty(returnValue) ? "" : ", ";
                returnValue += s;
            }

            return returnValue;
        }
    }

    public class Patient
    {
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string HomePhone { get; set; }
    }
}
