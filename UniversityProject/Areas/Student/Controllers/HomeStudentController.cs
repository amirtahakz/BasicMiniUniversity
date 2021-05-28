using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityProject.Areas.Student.Controllers
{
    public class HomeStudentController : Controller
    {
        // GET: Student/HomeStudent
        Models.db db = new Models.db();
        [Authorize(Roles = "1")] //student
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "1")] //student
        public ActionResult AllStudentLesson()
        {
            var data = db.Lessons.ToList();
            return View(data);
        }
        [Authorize(Roles = "1")] //student
        public ActionResult SelectLesson(Models.SelectedLesson s1)
        {
            db.SelectedLessons.Add(s1);
            db.SaveChanges();
            return RedirectToAction("AllLesson");
        }
        [Authorize(Roles = "1")] //student
        public ActionResult AllStudentLessons(int id)
        {
            var q = from i in db.SelectedLessons where i.UserId == id select i.Lesson;
            var data = q.ToList();
            return View(data);
        }

    }
}