using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository contactRepository = new ContactRepository();
        public ActionResult Index()
        {
            var values = contactRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(TblContact tblContact)
        {
            contactRepository.TAdd(tblContact);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteContact(int id)
        {
            TblContact t = contactRepository.Find(x => x.ContactId == id);
            contactRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditContact(int id)
        {
            TblContact t = contactRepository.Find(x => x.ContactId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditContact(TblContact p)
        {
            TblContact t = contactRepository.Find(x => x.ContactId == p.ContactId);
            t.NameSurname = p.NameSurname;
            t.Phone = p.Phone;
            t.Address = p.Address;
            t.Email = p.Email;
            contactRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}