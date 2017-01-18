using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using XposLIMS.Models;

namespace XposLIMS.Controllers
{
    [Authorize]
	public class UsersController : Controller
    {
		// GET: Users
		public bool isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				var context = new ApplicationDbContext();
				var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = userManager.GetRoles(user.GetUserId());
				if (s[0] == "Admin")
				{
					return true;
				}
			    return false;
			}
			return false;
		}
		public ActionResult Index()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				ViewBag.Name = user.Name;
				//	ApplicationDbContext context = new ApplicationDbContext();
				//	var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

				//var s=	UserManager.GetRoles(user.GetUserId());
				ViewBag.displayMenu = "No";

				if (isAdminUser())
				{
					ViewBag.displayMenu = "Yes";
				}
				return View();
			}
			else
			{
				ViewBag.Name = "Not Logged IN";
			}


			return View();


		}
	}
}