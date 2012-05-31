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
            return Json(patients.FindAll(p => p.ID == id), JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public JsonResult GetFolderList(string pid)
        {
            return Json(GetFolders(pid), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("Documents")]
        public JsonResult GetDocumentList(string pid)
        {
            return Json(GetDocuments(pid), JsonRequestBehavior.AllowGet);
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
                        DateOfBirth = "1990-01-01",
                        Address = GetAddress("1026 Montgomery Street^^Norristown^PA^19401^USA^^^CHITTENDEN"),
                        Gender = gender[i],
                        HomePhone = "(032)717-1234",
                        Folders = GetFolders(ids[i])
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

        private static List<Folder> GetFolders(string id)
        {
            return new List<Folder>(){
                new Folder{PatientId = id, Title="CT - Right Head", LastUpdateTime="2012-03-12"},
                new Folder{PatientId = id, Title="MRI - Knee", LastUpdateTime="2012-05-12"},
                new Folder{PatientId = id, Title="X-Ray - Left Hand", LastUpdateTime="2012-05-24"},
                new Folder{PatientId = id, Title="CT - Breast", LastUpdateTime="2012-06-12"},
            };
        }

        private static List<Document> GetDocuments(string pid)
        {
            return new List<Document>()
            {
                new Document
                { 
                    Comments = "Below is an example request and response from a Provide and Register Document Set-b transaction taken from a trace of the Public Registry. The original was chunk encoded (included header Transfer-Encoding: chunked). This encoding has been removed for readability. To make this a valid transaction either the chunked encoding would have to be redone or a Content-Length header would have to be added.",
                    AuthorPerson = "Kim Hyejin",
                    ContentType = "jpg",
                    PatientId = pid,
                    CreationTime = "2012-04-30",
                    Title = "X-Ray Right Brain",
                    Size = "155kb",
                    URI = "/Content/images/1.png",
                },
                new Document
                { 
                    Comments = "Below is an example request and response from a Provide and Register Document Set-b transaction taken from a trace of the Public Registry. The original was chunk encoded (included header Transfer-Encoding: chunked). This encoding has been removed for readability. To make this a valid transaction either the chunked encoding would have to be redone or a Content-Length header would have to be added.",
                    AuthorPerson = "Kim Hyejin",
                    ContentType = "jpg",
                    PatientId = pid,
                    CreationTime = "2012-04-30",
                    Title = "X-Ray Right Brain",
                    Size = "155kb",
                    URI = "/Content/images/2.png",
                },
                new Document
                { 
                    Comments = "Below is an example request and response from a Provide and Register Document Set-b transaction taken from a trace of the Public Registry. The original was chunk encoded (included header Transfer-Encoding: chunked). This encoding has been removed for readability. To make this a valid transaction either the chunked encoding would have to be redone or a Content-Length header would have to be added.",
                    AuthorPerson = "Kim Hyejin",
                    ContentType = "jpg",
                    PatientId = pid,
                    CreationTime = "2012-04-30",
                    Title = "X-Ray Right Brain",
                    Size = "155kb",
                    URI = "/Content/images/3.png",
                },
                new Document
                { 
                    Comments = "Below is an example request and response from a Provide and Register Document Set-b transaction taken from a trace of the Public Registry. The original was chunk encoded (included header Transfer-Encoding: chunked). This encoding has been removed for readability. To make this a valid transaction either the chunked encoding would have to be redone or a Content-Length header would have to be added.",
                    AuthorPerson = "Kim Hyejin",
                    ContentType = "jpg",
                    PatientId = pid,
                    CreationTime = "2012-04-30",
                    Title = "X-Ray Right Brain",
                    Size = "155kb",
                    URI = "/Content/images/4.png",
                }
            };
        }
    }

    public class Patient
    {
        public Patient()
        {
            this.Folders = new List<Folder>();
        }
        public string ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string HomePhone { get; set; }
        public List<Folder> Folders { get; set; }
    }

    public class Folder
    {
        public string Comments { get; set; }
        public string EntryUuid { get; set; }
        public string PatientId { get; set; }
        public string Title { get; set; }
        public string UniqueId { get; set; }
        public string HomeCommunityId { get; set; }
        public string LastUpdateTime { get; set; }
    }

    public class Document
    {
        public string Comments { get; set; }
        public string EntryUuid { get; set; }
        public string PatientId { get; set; }
        public string Title { get; set; }
        public string UniqueId { get; set; }
        public string RepositoryUniqueId { get; set; }
        public string HomeCommunityId { get; set; }
        public string AuthorPerson { get; set; }
        public string ContentType { get; set; }
        public string CreationTime { get; set; }
        public string Size { get; set; }
        public string URI { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
    }
}
