using System.Web.Http;

namespace APIMVCLearning.Controllers
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public IHttpActionResult  CheckHealthCheck()
        {
            return Json(new {message = "hello"});
        }
    }
}