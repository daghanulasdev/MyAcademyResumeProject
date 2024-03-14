using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class TeamController : Controller
    {
        // GET: Team
        TeamRepository teamRepository = new TeamRepository();
        public ActionResult Index()
        {
            var values = teamRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeam(TblTeam tblTeam)
        {
            teamRepository.TAdd(tblTeam);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTeam(int id)
        {
            TblTeam t = teamRepository.Find(x => x.TeamId == id);
            teamRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTeam(int id)
        {
            TblTeam t = teamRepository.Find(x => x.TeamId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditTeam(TblTeam p)
        {
            TblTeam t = teamRepository.Find(x => x.TeamId == p.TeamId);
            t.ImageUrl = p.ImageUrl;
            t.Title = p.Title;
            t.Description = p.Description;
            t.TwitterUrl = p.TwitterUrl;
            t.NameSurname = p.NameSurname;
            t.LinkedinUrl = p.LinkedinUrl;
            t.GithubUrl = p.GithubUrl;
            t.InstagramUrl = p.InstagramUrl;
            teamRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}