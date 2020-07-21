using dbpractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dbpractice.Controllers
{
    public class PersonController : Controller
    {
        iPersonRepository personRepo = new PersonRepository();
        // GET: Person
        [HttpGet]
        public ActionResult Index()
        {
            return View(personRepo.GetAllPersons());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person p)
        {
            int result = personRepo.Insert(p);
            if(result>0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(personRepo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Person p,int id)
        {
            p.Id = id;
            int result = personRepo.Update(p);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(personRepo.GetById(id));
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult Confirmdelete(int id)
        {
            
            int result = personRepo.Delete(id);
            if (result > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}