using System.Configuration;
using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;
using IdentityManager.Core.Logging;
using IdentityManager.Logging;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using XposLIMS.Models;

[assembly: OwinStartupAttribute(typeof(XposLIMS.Startup))]
namespace XposLIMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();

            LogProvider.SetCurrentLogProvider(new TraceSourceLogProvider());
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies",
                LoginPath= new PathString("/Account/Login")
            });

            
            app.Map("/idm", idm =>
            {
                var factory = new IdentityManagerServiceFactory
                {
                    IdentityManagerService = new Registration<IIdentityManagerService>(Create())
                };

                idm.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory,
                    SecurityConfiguration = new HostSecurityConfiguration
                    {
                        HostAuthenticationType = "Cookies",
                        NameClaimType = "name",
                        RoleClaimType = "role",
                        AdminRoleName = "Admin"
                    }
                });
            });
            
        }


		// In this method we will create default User roles and Admin user for login
		private void createRolesandUsers()
		{
			var context = new ApplicationDbContext();

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			// In Startup iam creating first Admin Role and creating a default Admin User 
			if (!roleManager.RoleExists("Admin"))
			{
				// first we create Admin rool
			    var role = new IdentityRole {Name = "Admin"};
			    roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website				

			    var user = new ApplicationUser
			    {
			        UserName = ConfigurationManager.AppSettings["SUserName"],
			        Email = "Panafrostar@gmail.com"
			    };

                var userPwd = ConfigurationManager.AppSettings["SUserPwd"];
				var chkUser = userManager.Create(user, userPwd);

				//Add default User to Role Admin
				if (chkUser.Succeeded)
				{
					var result1 = userManager.AddToRole(user.Id, "Admin");
				}
			}

			// creating Creating Manager role 
			if (!roleManager.RoleExists("Manager"))
			{
			    var role = new IdentityRole {Name = "Manager"};
			    roleManager.Create(role);
			}

			// creating Creating Employee role 
			if (!roleManager.RoleExists("Employee"))
			{
			    var role = new IdentityRole {Name = "Employee"};
			    roleManager.Create(role);
			}
		}

        private IIdentityManagerService Create()
        {
            var context =
              new IdentityDbContext(
                @"Data Source=localhost;Initial Catalog=XposLIMS;Integrated Security=true");

            var userStore = new UserStore<IdentityUser>(context);
            var userManager = new UserManager<IdentityUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var managerService =
              new AspNetIdentityManagerService<IdentityUser, string, IdentityRole, string>
                (userManager, roleManager);

            return managerService;
        }
    }
}
