using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace XposLIMS.BLL.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class NoGuestAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// The action to wich the request will be redirected if user is guest
        /// </summary>
        public string ActionToRedirect { get; set; }

        /// <summary>
        /// The Controller to wich the request will be redirected if user is guest
        /// </summary>
        public string ControllerToRedirect { get; set; }


        private readonly string m_DefaultAction = "Index";
        private readonly string m_DefaultController = "Home";

        public NoGuestAttribute()
        {
            ActionToRedirect = m_DefaultAction;
            ControllerToRedirect = m_DefaultController;
        }



        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.Request.IsAuthenticated)
            {
                filterContext.Result = SetRedirectToRouteResult();
            }           
            else
                base.OnActionExecuting(filterContext);
        }

        private RedirectToRouteResult SetRedirectToRouteResult()
        {
            var redirectTargetDictionary = new RouteValueDictionary
            {
                {"action", ActionToRedirect},
                {"controller", ControllerToRedirect}
            };
            return new RedirectToRouteResult(redirectTargetDictionary);
        }
    }
}