using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Mvc;
using APIMVCLearning.Models;
using APIMVCLearning.RequestPayload;
using APIMVCLearning.Utils.Response;
using Newtonsoft.Json;

namespace APIMVCLearning.Controllers
{
    public class UsersController : Controller
    {
        // GET
        [HttpGet]
        public JsonResult Index()
        {
            return new JsonResponse(new { message = "to do list user" });
        }
        
        [HttpPost]
        public ActionResult Index(User userPayload)
        {
            if (ModelState.IsValid) return new JsonResponse(userPayload);
            var listError = ModelState.Values.SelectMany(m => m.Errors).ToList();
            return new JsonResponse(400, listError);
        }
    }
}