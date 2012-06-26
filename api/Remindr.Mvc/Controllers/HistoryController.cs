using System.Web.Mvc;
using Remindr.Mvc.Models;
using Remindr.Model.Database;
using Remindr.Model.Ninject;

namespace Remindr.Mvc.Controllers
{
    public class HistoryController : Controller
    {
        IDatabaseAccess _databaseAccess = NinjectProvider.GetInstance<IDatabaseAccess>();
        [HttpGet]
        public JsonResult GetHistory(GetHistoryRequest request)
        {
            if (!string.IsNullOrEmpty(request.Id))
            {
                return Json(_databaseAccess.GetHistoryForNumber(request.Id), JsonRequestBehavior.AllowGet);
            }

            if (!string.IsNullOrEmpty(request.Number))
            {
                var countryCodeAndNumber = "+44" + request.Number.TrimStart('0');
                return Json(_databaseAccess.GetHistoryForNumber(countryCodeAndNumber), JsonRequestBehavior.AllowGet);
            }

            return Json(_databaseAccess.GetAllSentReminders(), JsonRequestBehavior.AllowGet);
        }
    }
}
