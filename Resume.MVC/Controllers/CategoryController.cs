using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            var values = categoryRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(TblCategory tblCategory)
        {
            categoryRepository.TAdd(tblCategory);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            TblCategory t = categoryRepository.Find(x => x.CategoryId == id);
            categoryRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            TblCategory t = categoryRepository.Find(x => x.CategoryId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditCategory(TblCategory p)
        {
            TblCategory t = categoryRepository.Find(x => x.CategoryId == p.CategoryId);
            t.CategoryName = p.CategoryName;
            categoryRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}