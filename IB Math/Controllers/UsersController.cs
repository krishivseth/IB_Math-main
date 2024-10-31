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
using System.Data.Entity.Validation;

namespace IB_Math.Controllers
{
    public class UsersController : Controller
    {
        private IB_MathEntities db = new IB_MathEntities();

       


        // GET: Users/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Register([Bind(Include = "User_id,User_password,User_fname,User_email,User_age,User_grade,User_Role,User_diagtestflag")] User user)
        {
            ModelState.Remove("User_email");
            var exist = db.Users.Where(e => e.User_email == user.User_email).SingleOrDefault();

            if (ModelState.IsValid && exist == null)
            {
                if(!String.IsNullOrEmpty(user.User_grade))
                {
                    user.User_Role = "1"; // Student
                }
                else
                {
                    user.User_Role = "2"; // Teacher
                }

                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Login");

            }
            else
            {
                ViewBag.Message = "This Email ID is already registered !";
                return RedirectToAction("Register");
            }
            return View(user);
        }
     
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]       
        public ActionResult Login(LoginModel um)
        {
            ModelState.Remove("User_password");
            ModelState.Remove("User_email");
            ModelState.Remove("User_fname");
            ModelState.Remove("User_daigtestflag");
            //ModelState.Remove("EmailAddress");

            if(ModelState.IsValid)
            {
               
                var login = db.Users.Where(e => e.User_email == um.User_email && e.User_password == um.User_password).SingleOrDefault();
                if (login != null)
                {
                    Session["UserName"] = login.User_fname;
                    Session["userid"] = login.User_id;
                    Session["useremail"] = login.User_email;
                    Session["User_Role"] = login.User_Role;
                    Session["test_flag"] = login.User_diagtestflag;

                    if (login.User_diagtestflag == null && login.User_Role == "1")
                    {
                        return RedirectToAction("Diagnostic_main", "DiagnosticTests");
                    }
                    else if(login. User_diagtestflag  == "y" && login.User_Role == "1")
                    {
                        return RedirectToAction("courses", "Dashboard");
                    }
                    else
                    {
                        return RedirectToAction("frontindex", "Dashboard");
                    }
                }
                else
                {
                    ViewBag.Message = "<script>alert('Invalid Email or password')</script>";
                    return View();
                }

            }
            else
            {
                return View(new User());
            }
           
        }

        public ActionResult IsUserNameAvailable(User um)
        {
            var data = db.Users.Where(u => u.User_email == um.User_email).FirstOrDefault();
            return Json(data == null, JsonRequestBehavior.AllowGet) ;
        }

        public ActionResult Logout()

        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<ActionResult> Profile()
        {
            var UserId = Session["Userid"].ToString();
            var profile = db.Users.Where(e => e.User_id.ToString() == UserId).SingleOrDefault();
            
            return View(profile);
        }


        [HttpPost]
        public async Task<ActionResult> Profile([Bind(Include = "User_id,User_password,User_fname,User_email,User_age,User_garde")] User up)
        {
            var UserId = Session["Userid"].ToString();
            var profile = db.Users.Where(e => e.User_id.ToString() == UserId).SingleOrDefault();
            
            profile.User_password = up.User_password;
           
            db.Entry(profile).State = EntityState.Modified;
            db.SaveChanges();
            Session.Abandon();
            return RedirectToAction("Login");
        }
        // GET: Users
        public async Task<ActionResult> Index()
        {            
            //var role = await db.Roles.Where(x => x.Role_id == data1).ToListAsync(;
            var data2 = (from user in db.Users join                          
                        role in db.Roles on user.User_Role equals role.Role_id.ToString()
                        select new 
                        {
                            User_name = user.User_fname,
                            User_Role = role.Role_name,
                            Age = user.User_age,
                            Email = user.User_email,
                            Class = user.User_class
                        }).ToList();

            var userlst = data2.Select(o => new User { User_fname = o.User_name, User_Role = o.User_Role,User_age = o.Age,User_email = o.Email ,User_class =o.Class})
                .ToList();

            return View(userlst);
        }



    }
}


//// GET: Users/Details/5
//public async Task<ActionResult> Details(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    User user = await db.Users.FindAsync(id);
//    if (user == null)
//    {
//        return HttpNotFound();
//    }
//    return View(user);
//}

//        // GET: Users/Edit/5
//        public async Task<ActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = await db.Users.FindAsync(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "User_id,User_name,User_password,User_fname,User_email,User_age,User_class,User_grade,User_academicposition,User_diagtestflag,CreatedBy,UpdatedBy,DeletedBy,CreatedAt,UpdatedAt,DeletedAt")] User user)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(user).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(user);
//        }

//        // GET: Users/Delete/5
//        public async Task<ActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            User user = await db.Users.FindAsync(id);
//            if (user == null)
//            {
//                return HttpNotFound();
//            }
//            return View(user);
//        }

//        // POST: Users/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(int id)
//        {
//            User user = await db.Users.FindAsync(id);
//            db.Users.Remove(user);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}

