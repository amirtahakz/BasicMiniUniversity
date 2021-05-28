using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversityProject.Areas.Manager.Controllers
{
    public class HomeManagerController : Controller
    {
        // GET: Manager/HomeManager
        Models.db db = new Models.db();
        [Authorize(Roles = "3")] //Manager
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult RegisterMaster()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "3")] //Manager
        public ActionResult RegisterMaster([Bind(Include = "CodeMelly,FullName,Password,RePassword,IdRole")] Models.MyUser u1)
        {
            if (ModelState.IsValid)
            {
                if (db.myusers.Any(x => x.CodeMelly == u1.CodeMelly))
                {
                    var alert = "شما قبلا ثبت نام کردید";
                    return View(alert, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    u1.IdRole = 2;
                    db.myusers.Add(u1);
                    db.SaveChanges();
                }
                return View();
            }
            return View(u1);
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult AddLesson()
        {
            return View();
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult AddNewLesson(Models.Lesson l1)
        {
            db.Lessons.Add(l1);
            db.SaveChanges();
            return RedirectToAction("AddLesson");
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult MastersUniversity()
        {
            var q = from i in db.myusers where i.IdRole == 2 select i;
            var data = q.ToList();
            return View(data);
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult StudentsUniversity()
        {
            var q = from i in db.myusers where i.IdRole == 1 select i;
            var data = q.ToList();
            return View(data);
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult DeleteStudent(int id)
        {
            var q = from i in db.myusers where i.UserId == id select i;
            var data = q.Single();
            db.myusers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("StudentsUniversity");
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult DeleteMaster(int id)
        {
            var q = from i in db.myusers where i.UserId == id select i;
            var data = q.Single();
            db.myusers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("StudentsUniversity");
        }
        [Authorize(Roles = "3")] //Manager
        public ActionResult UpdateStudent(Models.MyUser u1)
        {
            if (db.myusers.Any(x => x.CodeMelly == u1.CodeMelly))
            {
                var alert = "کد ملی تکراری است";
                return View(alert, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.myusers.FirstOrDefault(t => t.UserId == u1.UserId);
                data.FullName = u1.FullName;
                data.Password = u1.Password;
                data.RePassword = u1.RePassword;
                data.CodeMelly = u1.CodeMelly;
                db.SaveChanges();
            }
            return View();
        }

    }
}