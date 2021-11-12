using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoConectDatabase.Areas.Employes.Controllers
{
    public class HomeEmpController : Controller
    {
        [Authorize(Roles ="Quản trị")]

        // GET: Employes/HomeEmp
        public ActionResult Index()
        {
            return View();
        }
    }
}