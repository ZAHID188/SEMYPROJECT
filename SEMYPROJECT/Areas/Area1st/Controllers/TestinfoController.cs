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
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(id);
            }
            
        }
    }
}