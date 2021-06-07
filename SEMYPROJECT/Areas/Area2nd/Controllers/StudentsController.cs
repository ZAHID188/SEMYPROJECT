using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEMYPROJECT.Models;

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

        // GET: Area2nd/Students/Create
        public ActionResult Create()
        {
            ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName");
            ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName");
            ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName");
            return View();
        }

        // POST: Area2nd/Students/Create
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
            ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName", student.ClassNo);
            ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName", student.BornCountyID);
            ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName", student.GenderNo);
            return View(student);
        }

        // POST: Area2nd/Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SNo,SName,GenderNo,BornDate,BornCountyID,QQ,Phone,Email,AvatarPath,PhotoData,PhotoMimeType,ClassNo")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassNo = new SelectList(db.Classes, "ClassNo", "ClassName", student.ClassNo);
            ViewBag.BornCountyID = new SelectList(db.Counties, "CountyID", "CountyName", student.BornCountyID);
            ViewBag.GenderNo = new SelectList(db.Genders, "GenderNo", "GenderName", student.GenderNo);
            return View(student);
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
