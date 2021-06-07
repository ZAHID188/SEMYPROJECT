using SEMYPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEMYPROJECT.Areas.Remote.Controllers
{
    public class StudentsController : Controller
    {
        private TestDbContext db = new TestDbContext();
        // GET: Remote/Students
        public ActionResult CheckSNo(string SNo)
        {
            bool result = db.Students.FirstOrDefault(s => s.SNo == SNo) == null;
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckCountyID(string BornCountyID)
        {
            bool result = db.Counties.FirstOrDefault(c => c.CountyID == BornCountyID) != null;
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckQQ(string QQ , string SNo)
        {
            bool result = db.Students.FirstOrDefault(s => s.QQ == QQ) == null //new qq
                ||
                db.Students.FirstOrDefault(s => s.SNo == SNo && s.QQ == QQ) != null;
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public ActionResult CheckPhone(string Phone, string SNo)
        {
            bool result = db.Students
              .FirstOrDefault(s => s.Phone == Phone) == null // new QQ
              ||
              db.Students
              .FirstOrDefault(s => s.SNo == SNo && s.Phone == Phone) != null;
            //     You do NOT change Phone this time!!  ▲
            // We need understand, usually
            //   we don't change Primary Key -- SNo!!
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckEmail(string Email, string SNo)
        {
            bool result = db.Students.
              FirstOrDefault(s => s.Email == Email) == null //new Email
               || db.Students.FirstOrDefault(
                 s => s.SNo == SNo && s.Email == Email) != null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CheckClassNo(string ClassNo)
        {
            bool result = db.Classes.FirstOrDefault(c => c.ClassNo == ClassNo) != null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }
    }
}
    
