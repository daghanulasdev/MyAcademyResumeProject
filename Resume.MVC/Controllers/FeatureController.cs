using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class FeatureController : Controller
    {
        // GET: Feature
        FeatureRepository featureRepository = new FeatureRepository();
        public ActionResult Index()
        {
            var values = featureRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFeature(TblFeature tblFeature)
        {
            featureRepository.TAdd(tblFeature);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFeature(int id)
        {
            TblFeature t = featureRepository.Find(x => x.FeatureId == id);
            featureRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditFeature(int id)
        {
            TblFeature t = featureRepository.Find(x => x.FeatureId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditFeature(TblFeature p)
        {
            TblFeature t = featureRepository.Find(x => x.FeatureId == p.FeatureId);
            t.ImageUrl = p.ImageUrl;
            t.Title = p.Title;
            t.NameSurname = p.NameSurname;
            featureRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}