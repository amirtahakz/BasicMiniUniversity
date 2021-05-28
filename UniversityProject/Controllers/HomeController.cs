using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace UniversityProject.Controllers
{
    public class HomeController : Controller
    {
        Models.db db = new Models.db();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStudent([Bind(Include = "CodeMelly,FullName,Password,RePassword,IdRole")] Models.MyUser u1)
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
                    u1.IdRole = 1;
                    db.myusers.Add(u1);
                    db.SaveChanges();
                }
                return View();
            }
            return View(u1);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "CodeMelly,FullName,Password,RePassword,IdRole")] Models.MyUser u1, string returnUrl)
        {
            var CheckVerify = db.myusers.FirstOrDefault(t => t.CodeMelly == u1.CodeMelly && t.Password == u1.Password);
            if (!ModelState.IsValid)
            {
                var alert2 = "رمز عبور با نام کاربری مطابقت ندارد";
                if (CheckVerify != null)
                {
                    if (CheckVerify.IdRole == 2)
                    {
                        FormsAuthentication.SetAuthCookie(CheckVerify.UserId.ToString(), false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                 && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        Session["FullName"] = CheckVerify.FullName;
                        return RedirectToAction("Index", "HomeMaster", new { area = "Master" });
                    }
                    else if (CheckVerify.IdRole == 1)
                    {
                        FormsAuthentication.SetAuthCookie(CheckVerify.UserId.ToString(), false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                 && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        Session["FullName"] = CheckVerify.FullName;
                        return RedirectToAction("Index", "HomeStudent", new { area = "Student" });

                    }
                    else if (CheckVerify.IdRole == 3)
                    {
                        FormsAuthentication.SetAuthCookie(CheckVerify.UserId.ToString(), false);
                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                 && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        Session["FullName"] = CheckVerify.FullName;
                        return RedirectToAction("Index", "HomeManager", new { area = "Manager" });
                    }

                }
                else
                {
                    return Json(alert2, JsonRequestBehavior.AllowGet);
                }
            }
            return View(u1);
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    }
}
