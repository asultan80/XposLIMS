using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using XposLIMS.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace XposLIMS.Controllers
{
    [Authorize]
	public class RoleController : Controller
    {
		ApplicationDbContext context;

		public RoleController()
		{
			context = new ApplicationDbContext();
		}

		/// <summary>
		/// Get All Roles
		/// </summary>
		/// <returns></returns>
		public ActionResult Index()
		{

			if (User.Identity.IsAuthenticated)
			{
				if (!isAdminUser())
				{
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

			var roles = context.Roles.ToList();
			return View(roles);

		}
		public Boolean isAdminUser()
		{
			if (User.Identity.IsAuthenticated)
			{
				var user = User.Identity;
				var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
				var s = UserManager.GetRoles(user.GetUserId());
				if (s[0] == "Admin")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
		/// <summary>
		/// Create  a New role
		/// </summary>
		/// <returns></returns>
		public ActionResult Create()
		{
			if (User.Identity.IsAuthenticated)
			{
				if (!isAdminUser())
				{
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

			var role = new IdentityRole();
			return View(role);
		}

		/// <summary>
		/// Create a New Role
		/// </summary>
		/// <param name="role"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(IdentityRole role)
		{
			if (User.Identity.IsAuthenticated)
			{
				if (!isAdminUser())
				{
					return RedirectToAction("Index", "Home");
				}
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}

			context.Roles.Add(role);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}