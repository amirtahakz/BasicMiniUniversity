using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityProject.Areas.Master.Controllers
{
    public class HomeMasterController : Controller
    {
        // GET: Master/HomeMaster
        Models.db db = new Models.db();
        [Authorize(Roles = "2")] //Master
        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "2")] //Master
        public ActionResult AllLesson()
        {
            var data = db.Lessons.ToList();
            return View(data);
        }
        [Authorize(Roles = "2")] //Master
        public ActionResult SelectLesson(Models.SelectedLesson s1)
        {
            db.SelectedLessons.Add(s1);
            db.SaveChanges();
            return RedirectToAction("AllLesson");
        }
        [Authorize(Roles = "2")] //Master
        public ActionResult AllMasterLessons(int id)
        {
            var q = from i in db.SelectedLessons where i.UserId == id select i.Lesson;
            var data = q.ToList();
            return View(data);
        }
    }
}