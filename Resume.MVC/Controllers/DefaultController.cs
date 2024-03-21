using Resume.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class DefaultController : Controller
    {
        //[AllowAnonymous]
        // GET: Default
        MyAcademyDbEntities db = new MyAcademyDbEntities();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Feature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult About()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult Skill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public PartialViewResult Service()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult Experience()
        {
            var values = db.TblExperience.ToList();
            return PartialView(values);
        }
        public PartialViewResult Category()
        {
            var values = db.TblCategory.ToList();
            return PartialView(values);
        }
        public PartialViewResult Project()
        {
            var values = db.TblProject.ToList();
            return PartialView(values);
        }
        public PartialViewResult Testimonial()
        {
            var values = db.TblTestimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult Team()
        {
            var values = db.TblTeam.ToList();
            return PartialView(values);
        }
        [HttpGet]
        public PartialViewResult Message()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Message(TblMessage m)
        {
            db.TblMessage.Add(m);
            db.SaveChanges();
            return PartialView();
        } 
        
    }
}