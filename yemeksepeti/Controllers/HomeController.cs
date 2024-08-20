using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yemeksepeti.Models;

namespace yemeksepeti.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
       
        public ActionResult Contact()
        {
            ViewBag.OnlineUyeSayisi = HttpContext.Application["OnlineUyeSayisi"];

            return View();
        }
        baglanti model = new baglanti();
        yemeksepetiEntities2 db = new yemeksepetiEntities2();
        public ActionResult siparisdropdown()
        {
            List<user> userList = db.user.OrderBy(f => f.user_name).ToList();
            model.userList = (from u in userList
                                 select new SelectListItem
                                 {
                                     Text = u.user_name,
                                     Value = u.user_id.ToString()

                                 }
                            ).ToList();
            return View(model);
        }
        [HttpPost]
        public JsonResult GetsiparisList(int id)
        {
            List<siparis> siparisList = db.siparis.Where(f => f.user_id == id).OrderBy(f => f.yemek_id).ToList();
            List<SelectListItem> itemlist = (from s in siparisList select new SelectListItem
                                             {
                                                 Text = s.yemek_id,
                                                 Value = s.siparis_id.ToString()

                                             }).ToList();
            return Json(itemlist, JsonRequestBehavior.AllowGet);
        }
    }
}
