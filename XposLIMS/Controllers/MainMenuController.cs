using System.Web.Mvc;
using XposLIMS.BLL.Attributes;

namespace XposLIMS.Controllers
{
    public class MainMenuController : Controller
    {
        // GET: MainMenu
        [NoGuest]
        public ActionResult Index()
        {           
            return View();
        }
    }
}