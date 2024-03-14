using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository experienceRepository = new ExperienceRepository();
        public ActionResult Index()
        {
            var values = experienceRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperience tblExperience)
        {
            experienceRepository.TAdd(tblExperience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            TblExperience t = experienceRepository.Find(x => x.ExperienceId == id);
            experienceRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditExperience(int id)
        {
            TblExperience t = experienceRepository.Find(x => x.ExperienceId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditExperience(TblExperience p)
        {
            TblExperience t = experienceRepository.Find(x => x.ExperienceId == p.ExperienceId);
            t.Title = p.Title;
            t.SubTitle = p.SubTitle;
            t.Description = p.Description;
            t.Date = p.Date;
            experienceRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}