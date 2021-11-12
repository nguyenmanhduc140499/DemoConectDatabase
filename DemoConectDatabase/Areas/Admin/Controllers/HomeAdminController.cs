using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoConectDatabase.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [Authorize(Roles = "Quản trị")]
        // GET: Admin/HomeAdmin
        public ActionResult Index()
        {
            return View();
        }
    }
}