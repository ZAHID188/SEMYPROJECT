using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SEMYPROJECT.Models;

namespace SEMYPROJECT.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index( string id)
        {
            //learn id

            if (id == null)
            {
                return View();
            }
            else
                return View(id);
            
        }

        public ActionResult DisplayRouteInfo(string id)
        {
            ViewBag.Controller = RouteData.Values["controller"].ToString();
            ViewBag.Action = RouteData.Values["action"].ToString();
            // ViewBag.ID = RouteData.Values["id"].ToString();
            ViewBag.ID = RouteData.Values["id"] as string;
            // as= target type == convert the former object /variable to target-type,  if fails return null value
            // we will not have to face any exception as like last time.
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Submit()
        {
            return View();

        }
        // [HttpPost]
        public ActionResult SubmitPlus()
        {


            // i can also use--string username = Request.QueryString["user"]
            string username = Request["user"];
            string password = Request["pwd"];
            int age = int.Parse(Request["age"]);

            string resultToDisplay = $"Name: {username}<br>" +
                $"Password:{password}<br>" +
                $"Age:{age}";

            ViewBag.Result = resultToDisplay;
            return View();

        }
        public ActionResult Submit2()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Submit2Plus()
        {
            //also ok
            //string username = Request["user"];
            //  string password = Request["pwd"];
            //  int age = int.Parse(Request["age"]);


            // i can also use--string username = Request.QueryString["user"]
            string username = Request.Form["user"];
            string password = Request.Form["pwd"];
            int age = int.Parse(Request.Form["age"]);

            string resultToDisplay = $"Name: {username}<br>" +
                $"Password:{password}<br>" +
                $"Age:{age}";

            ViewBag.Result = resultToDisplay;
            return View();

        }
        [HttpPost]
        public ActionResult Submit2Plus2(FormCollection collection)
        {
            // collection also same bring the string format
            string username = collection["user"];
            string password = collection["pwd"];
            int age = int.Parse(collection["age"]);


           string resultToDisplay = $"Name: {username}<br>" + 
                $"Password:{password}<br>" +
                $"Age:{age}";

            ViewBag.Result = resultToDisplay;
            return View();
            

           
        }
        [HttpPost]
        public ActionResult Submit2Plus3([Bind(Include ="user,pwd,age")] User1 _user)
        {
            return View(_user);
        }

        [HttpPost]
        public ActionResult Submit2Plus4(string user,string pwd, int age)
        {
            string resultToDisplay = $"Name: {user}<br>" +
               $"Password:{pwd}<br>" +
               $"Age:{age}";

            ViewBag.Result = resultToDisplay;
            return View();
        }
    }
}

  