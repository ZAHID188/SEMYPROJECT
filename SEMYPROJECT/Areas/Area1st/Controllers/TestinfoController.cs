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

        // for ajax request we just need to
        // return partial view(layout will be neglected)

            //return View() == returns with the layout
        public ActionResult AjaxOrNonAjax()
        {
            // if the request is in the ajax then we don't need to show the layout .
            // so we used this condition.
            if(Request.IsAjaxRequest()) 
                return PartialView();
            else
                return View();
        }
           
          
         
            
       
    }
}