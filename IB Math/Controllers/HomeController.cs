using IB_Math.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IB_Math.Controllers
{
    public class HomeController : Controller
    {
        private IB_MathEntities db = new IB_MathEntities();
        // GET: Default
        public ActionResult index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult CourseDetails (int id)
        {
            ViewBag.Courses = db.Courses.Where(x => x.Course_id == id).ToList();
            return View();
        }
    }
}