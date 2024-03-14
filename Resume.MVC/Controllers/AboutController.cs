using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutRepository aboutRepository = new AboutRepository();
        public ActionResult Index()
        {
            var values = aboutRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(TblAbout tblAbout) 
        {
            aboutRepository.TAdd(tblAbout);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id) 
        {
            TblAbout t = aboutRepository.Find(x=>x.AboutId == id);
            aboutRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet] 
        public ActionResult EditAbout(int id) 
        {
            TblAbout t = aboutRepository.Find(x => x.AboutId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditAbout(TblAbout p)
        {
            TblAbout t = aboutRepository.Find(x => x.AboutId == p.AboutId);
            t.ImageUrl = p.ImageUrl;
            t.Title = p.Title;
            t.Description = p.Description;
            aboutRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}