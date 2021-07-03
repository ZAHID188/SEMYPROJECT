using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEMYPROJECT.Models;

namespace SEMYPROJECT.Controllers
{
    public class ImageController : Controller
    
    {
       // private TestDbContext db = new TestDbContext();
        // GET: Image
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
         public ActionResult Add(Image imageModel)
        {

            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Upload/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Upload/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            using (TestDbContext db2 = new TestDbContext())
            {
                db2.Image.Add(imageModel);
                db2.SaveChanges();
            }
                
            
       
            ModelState.Clear();

            return View();

        }

    }
}