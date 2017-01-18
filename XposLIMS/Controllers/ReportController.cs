using Kendo.Mvc.Extensions;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XposLIMS.Models;

namespace XposLIMS.Controllers
{
    public class ReportController : Controller
    {
        private readonly XposLIMSEntities _db = new XposLIMSEntities();

        public ReportController (){}

        // GET: Report
        
        public ActionResult Index()
        {
            var reports = from m in _db.ReportXes.Where(e=> e.Visible ==1)
                           select m;

            var reportVM = new ReportViewModel()
            {
                reports = reports.ToList(),
                ModuleName = "LIMS Reporting"
            };
            return View(reportVM);
        }

        public string ReportName(string id) => HttpUtility.HtmlEncode("ReportName is " + id);
    }
}