using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        MessageRepository messageRepository = new MessageRepository();
        public ActionResult Index()
        {
            var values = messageRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMessage(TblMessage tblMessage)
        {
            messageRepository.TAdd(tblMessage);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMessage(int id)
        {
            TblMessage t = messageRepository.Find(x => x.MessageId == id);
            messageRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditMessage(int id)
        {
            TblMessage t = messageRepository.Find(x => x.MessageId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditMessage(TblMessage p)
        {
            TblMessage t = messageRepository.Find(x => x.MessageId == p.MessageId);
            t.Name = p.Name;
            t.Message = p.Message;
            t.Subject = p.Subject;
            t.Email = p.Email;
            messageRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}