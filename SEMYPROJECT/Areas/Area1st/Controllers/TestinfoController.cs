using SEMYPROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEMYPROJECT.Areas.Area1st.Controllers
{
    public class TestinfoController : Controller
    {
        // GET: Area1st/Testinfo
        public ActionResult Index(string id)
        {
            ViewBag.Xuser = new User1
            {
                user = "Rofiq",
                pwd = "1234",
                age = 24
            };


            if (id == null)
            {
                return View();
            }
            else
            {
                return View(id);
            }
            
        }
        public ActionResult  AjaxOrNonAjax()
        {
            return View();
        }
        public ActionResult Page()
        {
            return View();
        }
    }
}