using Resume.MVC.Models;
using Resume.MVC.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        ProjectRepository projectRepository = new ProjectRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            var values = projectRepository.GetList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddProject()
        {
            var categories = categoryRepository.GetList();
            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(TblProject tblProject)
        {
            projectRepository.TAdd(tblProject);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            TblProject t = projectRepository.Find(x => x.ProjectId == id);
            projectRepository.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditProject(int id)
        {
            var categories = categoryRepository.GetList();
            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();
            ViewBag.category = categoryList;
            TblProject t = projectRepository.Find(x => x.ProjectId == id);
            return View(t);
        }

        [HttpPost]
        public ActionResult EditProject(TblProject p)
        {
            TblProject t = projectRepository.Find(x => x.ProjectId == p.ProjectId);
            t.ImageUrl = p.ImageUrl;
            t.ProjectName = p.ProjectName;
            t.ProjectUrl = p.ProjectUrl;
            t.CategoryId = p.CategoryId;
            projectRepository.TUpdate(t);
            return RedirectToAction("Index");

        }
    }
}