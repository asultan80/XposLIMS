using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XposLIMS.BLL.Attributes;

namespace XposLIMS.Controllers
{
    public class PlantController : Controller
    {
        // GET: Plant
        [NoGuest]
        public ActionResult Index()
        {
            return View();
        }
    }
}