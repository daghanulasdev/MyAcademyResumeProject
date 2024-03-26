using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        ServiceRepository serviceRepository = new ServiceRepository();
        public ActionResult Index()
        {
            var values = serviceRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService tblService)
        {
            serviceRepository.TAdd(tblService);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            TblService t = serviceRepository.Find(x => x.ServiceId == id);
            serviceRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditService(int id)
        {
            TblService t = serviceRepository.Find(x => x.ServiceId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditService(TblService p)
        {
            TblService t = serviceRepository.Find(x => x.ServiceId == p.ServiceId);
            t.Icon = p.Icon;
            t.Title = p.Title;
            t.Description = p.Description;
            t.Status = p.Status;
            serviceRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}