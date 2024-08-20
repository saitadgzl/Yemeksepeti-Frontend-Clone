using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yemeksepeti.Models;

namespace yemeksepeti.Controllers
{
    public class GirisController : Controller
    {
        public ActionResult Hakkinda()
        {
            return View();
        }
        // GET: Giris
        public ActionResult Giris()
        {
            return View();
        }

        yemeksepetiEntities2 db = new yemeksepetiEntities2();
        public ActionResult RestorantGiris()
        {
            return View();
        }
        public ActionResult Servisler()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestorantGiris(restoran r)
        {
            var bilgiler = db.restoranlar
                .FirstOrDefault(x => x.restoranadı == r.restoran_adı );
            if (bilgiler != null)
            {
                Session["restoran_adı"] = bilgiler.restoranadı.ToString();
                //Session["sifre"] = bilgiler.sifre.ToString();
                return RedirectToAction("Contact", "Home");
            }
            else
            {

                return Content("<script language='javascript' type='text/javascript'>" +
                     "alert('Kullanıcı adı veya şifre hatalı.');</script>");
            }

        }
        public ActionResult UyeGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeGiris(user s)
        {
            var bilgiler = db.user
                .FirstOrDefault(x => x.user_name == s.user_name && x.password == s.password);
            if (bilgiler != null)
            {
                Session["user_name"] = bilgiler.user_name.ToString();
                Session["password"] = bilgiler.password.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {

                return Content("<script language='javascript' type='text/javascript'>" +
                     "alert('Kullanıcı adı veya şifre hatalı.');</script>");
            }




        }
        public ActionResult Anagiris()
        {
            return View();
        }
    }
}