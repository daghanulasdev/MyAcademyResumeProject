using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resume.MVC.Controllers
{
    public class DefaultLayoutController : Controller
    {
        // GET: DefaultLayout
        public PartialViewResult DefaultLayoutHead()
        {
            return PartialView();
        }
        public PartialViewResult DefaultLayoutNavbar()
        {
            return PartialView();
        }
        public PartialViewResult DefaultLayoutScript()
        {
            return PartialView();
        }
    }
}