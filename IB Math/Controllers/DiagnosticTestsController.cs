using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IB_Math.Models;
using IB_Math.Authentication_filter;

namespace IB_Math.Controllers
{
    [CustomAuthenticationFilter]
    public class DiagnosticTestsController : Controller
    {
        private IB_MathEntities db = new IB_MathEntities();

        // GET: DiagnosticTests
        public async Task<ActionResult> Index()
        {
            var diagnosticTests = db.DiagnosticTests.Include(d => d.UsersDiagnostictests);
            return View(await diagnosticTests.ToListAsync());
        }

        // GET: DiagnosticTests/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiagnosticTest diagnosticTest = await db.DiagnosticTests.FindAsync(id);
            if (diagnosticTest == null)
            {
                return HttpNotFound();
            }
            return View(diagnosticTest);
        }

        // GET: DiagnosticTests/Create
        public ActionResult Create()
        {
           // ViewBag.Course_id = new SelectList(db.Courses, "Course_id", "Course_name");
            
          SelectListItem Course = new SelectListItem();
            ViewBag.Course_id = db.Courses.Select(x => new SelectListItem { Text = x.Course_name, Value = x.Course_id.ToString() }).ToList();

            return View();
        }


        // POST: DiagnosticTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Diagtest_id,Diagtest_name,CraetedAt,UpdatedAt,DeletedAt,CreatedBy,UpdatedBy,Deletedby,Course_id,Diagtest_que,Option1,Option2,Option3,Option4,Weightage,Diagtest_answer")] DiagnosticTest diagnosticTest)
        {
            if (ModelState.IsValid)
            {
                db.DiagnosticTests.Add(diagnosticTest);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Course_id = new SelectList(db.Courses, "Course_id", "Course_name", diagnosticTest.Course_id);
            return View(diagnosticTest);
        }

        // GET: DiagnosticTests/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiagnosticTest diagnosticTest = await db.DiagnosticTests.FindAsync(id);
            if (diagnosticTest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_id = new SelectList(db.Courses, "Course_id", "Course_name", diagnosticTest.Course_id);
            return View(diagnosticTest);
        }

        // POST: DiagnosticTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Diagtest_id,Diagtest_name,CraetedAt,UpdatedAt,DeletedAt,CreatedBy,UpdatedBy,Deletedby,Course_id,Diagtest_que,Option1,Option2,Option3,Option4,Weightage,Diagtest_answer")] DiagnosticTest diagnosticTest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diagnosticTest).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Course_id = new SelectList(db.Courses, "Course_id", "Course_name", diagnosticTest.Course_id);
            return View(diagnosticTest);
        }

        // GET: DiagnosticTests/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiagnosticTest diagnosticTest = await db.DiagnosticTests.FindAsync(id);
            if (diagnosticTest == null)
            {
                return HttpNotFound();
            }
            return View(diagnosticTest);
        }

        // POST: DiagnosticTests/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DiagnosticTest diagnosticTest = await db.DiagnosticTests.FindAsync(id);
            db.DiagnosticTests.Remove(diagnosticTest);
            await db.SaveChangesAsync();
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
        [HttpGet]
        public ActionResult DiagnosticTests_mcqtest()
        {
            var Model = db.DiagnosticTests.ToList();
            return View(Model);
        }

        [HttpPost]
        public async Task<ActionResult> DiagnosticTests_mcqtest(List<DiagnosticTest> Model)
        {
            var obj = db.DiagnosticTests.ToList();
            var sum = 0;
            for (var item = 0; item < obj.Count(); item++)
            {
                if (obj[item].Diagtest_answer == Model[item].Diagtest_answer)
                {
                    // sum += obj[item].Weightage;
                    DaigtestAn Answers = new DaigtestAn();
                    // Answers.Diagtest_Ans = obj[item].Diagtest_answer;
                    Answers.student_id = Convert.ToInt32(Session["userid"]);
                    Answers.Course_Id = obj[item].Course_id;
                    Answers.Diagtest_Score = obj[item].Weightage.ToString();
                    db.DaigtestAns.Add(Answers);
                    
                }
            }
            // Update user flag
            // 
            Session["test_flag"] = "y";
            db.Users.Find(Convert.ToInt32(Session["userid"])).User_diagtestflag = "y";
            await db.SaveChangesAsync(); // Save all at once 
            return RedirectToAction("Diagnostic_mcqresult");
        }
        public ActionResult Diagnostic_mcqresult()
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

        public ActionResult Diagnostic_main()
        {
            return View();
        }

    }
}
