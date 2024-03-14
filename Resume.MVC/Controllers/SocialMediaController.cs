using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository socialMediaRepository = new SocialMediaRepository();
        public ActionResult Index()
        {
            var values = socialMediaRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia tblSocialMedia)
        {
            socialMediaRepository.TAdd(tblSocialMedia);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            TblSocialMedia t = socialMediaRepository.Find(x => x.SocialMediaId == id);
            socialMediaRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            TblSocialMedia t = socialMediaRepository.Find(x => x.SocialMediaId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditSocialMedia(TblSocialMedia p)
        {
            TblSocialMedia t = socialMediaRepository.Find(x => x.SocialMediaId == p.SocialMediaId);
            t.SocialMediaName = p.SocialMediaName;
            t.SocialMediaIcon = p.SocialMediaIcon;
            t.Url = p.Url;
            socialMediaRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}