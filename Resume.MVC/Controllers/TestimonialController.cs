using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class TestimonialController : Controller
    {
        // GET: Testimonial
        TestimonialRepository testimonialRepository = new TestimonialRepository();
        public ActionResult Index()
        {
            var values = testimonialRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonial tblTestimonial)
        {
            testimonialRepository.TAdd(tblTestimonial);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            TblTestimonial t = testimonialRepository.Find(x => x.TestimonialId == id);
            testimonialRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTestimonial(int id)
        {
            TblTestimonial t = testimonialRepository.Find(x => x.TestimonialId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditTestimonial(TblTestimonial p)
        {
            TblTestimonial t = testimonialRepository.Find(x => x.TestimonialId == p.TestimonialId);
            t.ImageUrl = p.ImageUrl;
            t.Title = p.Title;
            t.CustomerName = p.CustomerName;
            t.Comment = p.Comment;
            t.Status = p.Status;
            testimonialRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}