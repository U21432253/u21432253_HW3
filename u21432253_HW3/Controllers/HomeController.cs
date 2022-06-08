using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21432253_HW3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string radioButton)
        {
            ViewBag.Msg = radioButton;
            switch (radioButton)
            {
                case "Image":
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Images/"), file.FileName));
                    break;
                case "Video":
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Videos/"), file.FileName));
                    break;
                case "Document":
                    file.SaveAs(Path.Combine(HttpContext.Server.MapPath("~/Media/Documents/"), file.FileName));
                    break;
                default:
                    ViewBag.Msg = "Please sellect a file type or file";
                    break;
            }
            return View();
        }

        
    }
}