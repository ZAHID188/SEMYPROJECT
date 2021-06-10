using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEMYPROJECT.Models;
using SEMYPROJECT.ViewModels;

namespace SEMYPROJECT.Areas.Area2nd.Controllers
{
    public class StudentsController : Controller
    {
        private TestDbContext db = new TestDbContext();

        // GET: Area2nd/Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Class).Include(s => s.County).Include(s => s.Gender);
            return View(students.ToList());
        }

        // GET: Area2nd/Students/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        public EditableStudent PrepareData4EditStudent(Student s)
        
                {
                //We need to set the data for the dropdownlists such as
                //  province,city,county; YzuSchool, YzuMajor and Class
                //❶ default values for dropdownlist:
                var cityID = db.Counties.FirstOrDefault(m =>
                  m.CountyID == s.BornCountyID).CityID;
                var provinceID = db.Cities.FirstOrDefault(m =>
                  m.CityID == cityID).ProvinceID;
                var majorID = db.Classes.FirstOrDefault(m =>
                  m.ClassNo == s.ClassNo).MajorID;
                var schoolID = db.YzuMajors.FirstOrDefault(m =>
                  m.MajorID == majorID).SchoolID;
                //❷ Prepare the object data for the view using ~/ViewModels/EditableStudent:
                EditableStudent es = new EditableStudent
                {
                    SNo = s.SNo,
                    SName = s.SName,
                    GenderNo = s.GenderNo,
                    BornDate = s.BornDate,
                    //Province-City-County
                    ProvinceID = provinceID,
                    CityID = cityID,
                    BornCountyID = s.BornCountyID,

                    QQ = s.QQ,
                    Phone = s.Phone,
                    Email = s.Email,
                    AvatarPath = s.AvatarPath,

                    //YzuSchool-YzuMajor-Class
                    SchoolID = schoolID,
                    MajorID = majorID,
                    ClassNo = s.ClassNo
                };

            //Prepare the data for Gender dropdownlist:
            ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName", s.GenderNo);
            //Prepare the data for Province-City-County dropdownlist:
            var provinces = new SelectList(db.Provinces, "ProvinceID", "ProvinceName", provinceID); // ..., es.ProvinceID);
            var cities = new SelectList(db.Cities.Where(c => c.ProvinceID == provinceID), "CityID", "CityName", cityID); //es.CityID
            var counties = new SelectList(db.Counties.Where(c => c.CityID == cityID), "CountyID", "CountyName", s.BornCountyID);
            //set the ViewBag object
            ViewBag.ProvinceID = provinces;
            ViewBag.CityID = cities;
            ViewBag.BornCountyID = counties;

            //Prepare the data for School-Major-Class dropdownlist:
            var schools = new SelectList(db.YzuSchools, "SchoolID", "SchoolName", schoolID);
            var majors = new SelectList(db.YzuMajors.Where(m => m.SchoolID == schoolID), "MajorID", "MajorName", majorID);
            var classes = new SelectList(db.Classes.Where(c => c.MajorID == majorID), "ClassNo", "ClassName", s.ClassNo);
            //set the ViewBag object
            ViewBag.SchoolID = schools;
            ViewBag.MajorID = majors;
            ViewBag.ClassNo = classes;

            return es;
        }




        // GET: Area2nd/Students/Create
        public ActionResult Create()
        {
            // ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName");
            //  ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName");
            //   ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName");
            Student s = new Student()
            {
                BornDate = new DateTime(DateTime.Now.Year - 20, 6, 15),//2001-09-17
                BornCountyID = "110101",
                ClassNo = "RJ1801"
            };

            EditableStudent e = PrepareData4EditStudent(s);
            return View("Edit", e); //Edit.cshtml and pass an object e for it
        }

        /*  // POST: Area2nd/Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SNo,SName,GenderNo,BornDate,BornCountyID,QQ,Phone,Email,AvatarPath,PhotoData,PhotoMimeType,ClassNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName", student.ClassNo);
            ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName", student.BornCountyID);
            ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName", student.GenderNo);
            return View(student);
        }
        */
        // GET: Area2nd/Students/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            // ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName", student.ClassNo);
            // ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName", student.BornCountyID);
            // ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName", student.GenderNo);
            EditableStudent es = PrepareData4EditStudent(student);
            return View(es);
             
            //return View(student);
        }

        // POST: Area2nd/Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNo,SName,GenderNo,BornDate,BornCountyID,QQ,Phone,Email,AvatarPath,PhotoData,PhotoMimeType,ClassNo")] Student student, HttpPostedFileBase AvatarUploader = null, HttpPostedFileBase Photo = null)
        {
            if (ModelState.IsValid)
            {
                //【1】 Save the image for avatar in the os directory ~/Upload/
                //          the image filename(abc.jpg) is saved in database.
                var imgFileName = ""; //Not provided
                if (AvatarUploader != null)
                {
                    //Make sure the directory "~/Upload" exist!!
                    // using System.IO; //for Path.Combine("root-part", "sub-part")
                    //                        D:\wxw\SE2018\SE2018\Upload\ ▼in my computer!
                    imgFileName = Path.Combine(Request.MapPath("~/Upload/"), Path.GetFileName(AvatarUploader.FileName));
                    try
                    {
                        AvatarUploader.SaveAs(imgFileName); //save the img file in the ~/Upload directory!
                        student.AvatarPath = Path.GetFileName(AvatarUploader.FileName); //abc.png/jpg
                    }
                    catch
                    {
                        return Content("Exception occurred while uploading avatar image....", "text/plain");
                    }
                }
                //【2】 Save the student's Photo data in the database in binary format:
                if (Photo != null)
                {
                    student.PhotoMimeType = Photo.ContentType;
                    student.PhotoData = new byte[Photo.ContentLength];
                    Photo.InputStream.Read(student.PhotoData, 0, Photo.ContentLength);
                }

                //db.Entry(student).State = EntityState.Modified;
                //db.SaveChanges();

                //We change the code for both 【Create Student】 and 【Edit Student】:
                if (db.Students.Find(student.SNo) != null)
                {
                    Student studentEntry = db.Students.Find(student.SNo);
                    if (studentEntry != null)
                    {
                        studentEntry.SName = student.SName;
                        studentEntry.GenderNo = student.GenderNo;
                        studentEntry.BornDate = student.BornDate;
                        studentEntry.BornCountyID = student.BornCountyID;
                        studentEntry.QQ = student.QQ;
                        studentEntry.Phone = student.Phone;
                        studentEntry.Email = student.Email;
                        studentEntry.AvatarPath = student.AvatarPath;
                        studentEntry.ClassNo = student.ClassNo;
                        if (Photo != null)
                        {
                            studentEntry.PhotoData = student.PhotoData;
                            studentEntry.PhotoMimeType = student.PhotoMimeType;
                        }
                    } //【for Edit Student】
                }
                else
                {
                    db.Students.Add(student); //【for Create Student】
                }
                db.SaveChanges(); //Save the record you're editing or creating!!

                return RedirectToAction("Index");

            }
            //ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName", student.ClassNo);
            //ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName", student.BornCountyID);
            //ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName", student.GenderNo);
            //return View(student);

            EditableStudent es = PrepareData4EditStudent(student);
            return View(es);
        }
        // GET: Area2nd/Students/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Area2nd/Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        /// <summary>
        /// Used in Edit.cshtml for access the binary data of the Photo.
        ///  We can access it by:
        ///  @Url.Action("GetPhoto")  OR @Html.Action("GetPhoto")
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[ChildActionOnly] //leads to the failure of loading Photo!

        [AllowAnonymous] //no need to login
        public FileContentResult GetPhoto(string id)
        {
            Student student = db.Students.FirstOrDefault(s => s.SNo == id);
            if(student != null)
            {
                byte[] arr = student.PhotoData;
                if (arr != null)
                    return File(student.PhotoData, student.PhotoMimeType);
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
