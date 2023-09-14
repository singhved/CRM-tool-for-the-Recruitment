using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduCare.Controllers
{
    public class MenusController : Controller
    {
        // GET: Menus
        public PartialViewResult Top()
        {
            return PartialView();
        }
        public PartialViewResult Side()
        {
            return PartialView();
        }
    }
}