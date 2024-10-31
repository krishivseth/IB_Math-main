using IB_Math.Authentication_filter;
using IB_Math.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;


namespace IB_Math.Controllers
{
   
    [CustomAuthenticationFilter]
    public class DashboardController : Controller
    {
        private IB_MathEntities db = new IB_MathEntities();


        // GET: Dashboard
        public ActionResult index()
        {
            return View();
        }

        // GET: Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Front Dashboard
        public ActionResult frontIndex()
        {
            SelectListItem stud = new SelectListItem();
            ViewBag.students = db.Users.Where(x => x.User_Role == "1").Select(x => new SelectListItem { Text = x.User_fname, Value = x.User_id.ToString() }).ToList();

            return View();
        }

        public ActionResult courses()
        {

            List<sp_GetStudentScore_Result> Results = new List<sp_GetStudentScore_Result>();
            var userid = Convert.ToInt32(Session["userid"]);
            var courses = db.Courses.ToList();
            foreach (var course in courses) // featch all the courses from the data base 
            {
                // Featch student and courses specific ans from the database 
                var answers = db.DaigtestAns.Where(e => e.student_id == userid && e.Course_Id == course.Course_id).ToList();
                // Count the correct ans result from the given test 
                sp_GetStudentScore_Result Result = new sp_GetStudentScore_Result();
                Result.Course_name = course.Course_name;
                Result.Course_id = course.Course_id;
                Result.User_fname = Session["UserName"].ToString();
                Result.Score = 0;
                foreach (var answer in answers)
                {
                    Result.Score += Int32.Parse(answer.Diagtest_Score);
                }
                Results.Add(Result);
            }

            return View(Results);
        }

        public ActionResult studCourses(int id)
        {
            List<sp_GetStudentScore_Result> Results = new List<sp_GetStudentScore_Result>();
            var userid = Convert.ToInt32(id);
            var courses = db.Courses.ToList();
            foreach (var course in courses) // featch all the courses from the data base 
            {
                // Featch student and courses specific ans from the database 
                var answers = db.DaigtestAns.Where(e => e.student_id == userid && e.Course_Id == course.Course_id).ToList();
                // Count the correct ans result from the given test 
                sp_GetStudentScore_Result Result = new sp_GetStudentScore_Result();
                Result.Course_name = course.Course_name;
                Result.Course_id = course.Course_id;
                Result.User_fname = id.ToString();
                Result.Score = 0;
                foreach (var answer in answers)
                {
                    Result.Score += Int32.Parse(answer.Diagtest_Score);
                }
                Results.Add(Result);
            }

            return PartialView("courses_partial_view", Results);
        }
    }
}

public class stud
{
    public string Course { get; set; }
    public string Name { get; set; }
    public string username { get; set; }

    public string userscore { get; set; }
}
