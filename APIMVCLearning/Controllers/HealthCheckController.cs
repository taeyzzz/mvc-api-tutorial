using System.Web.Mvc;

namespace APIMVCLearning.Controllers
{
    public class HealthCheckController : Controller
    {
        // GET
        [HttpGet]
        public JsonResult Index()
        {
            return Json(new { message = "API is running."}, JsonRequestBehavior.AllowGet);
        }
    }
}