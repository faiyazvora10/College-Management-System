using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using College_Management_System.Models;

namespace College_Management_System.Controllers
{
    public class HomeController : Controller
    {
        faiyazEntities obj = new faiyazEntities();
        public ActionResult Test()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Test(AdminLogin a)
        {
            var q = (from m in obj.AdminLogins where m.username.Equals(a.username) && m.password.Equals(a.password) select m).SingleOrDefault();
            if (q != null)
            {
                ViewBag.msg = "Login Successfully";
            }
            else
            {
                ViewBag.msg = "Invalid Username or Password";
            }
            return View(q);

        }

        


    }
}