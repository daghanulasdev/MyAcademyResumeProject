using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillRepository skillRepository = new SkillRepository();
        public ActionResult Index()
        {
            var values = skillRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkill tblSkill)
        {
            skillRepository.TAdd(tblSkill);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
            TblSkill t = skillRepository.Find(x => x.SkillId == id);
            skillRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            TblSkill t = skillRepository.Find(x => x.SkillId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditSkill(TblSkill p)
        {
            TblSkill t = skillRepository.Find(x => x.SkillId == p.SkillId);
            t.SkillName = p.SkillName;
            t.Value = p.Value;
            skillRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}