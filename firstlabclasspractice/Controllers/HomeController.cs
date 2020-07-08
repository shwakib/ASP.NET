using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace firstlabclasspractice.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "It is working";
        }

        public ActionResult Index1(int? id = null)
        {
            return RedirectToAction("anothermethod");
        }

        public string anothermethod(int? id=null)
        {
            if(id==null)
            {
                return "reponse from other method";
            }
            return "response from another method: "+id.ToString();
        }

        public ViewResult Index2()
        {
            return View();
        }
    }
}