using System.Web.Http;
using APIMVCLearning.Attributes;
using APIMVCLearning.Models;
using APIMVCLearning.Repositories;

namespace APIMVCLearning.Controllers
{
    [AuthenticationFilter]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        public static UserRepository userRepo = new UserRepository();

        [HttpGet]
        public IHttpActionResult ListUser()
        {
            return Json(userRepo.listUsers());
        }

        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            return Json(userRepo.getUserById(id));
        }

        [HttpPost]
        public IHttpActionResult CreateUser([FromBody] User userPayload)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var newUser = userRepo.createUser(userPayload);
            return Json(newUser);
        }

        [HttpPatch]
        public IHttpActionResult UpdateUser([FromBody] User userPayload, [FromUri] int id)
        {
            return Json(userPayload);
        }
    }
}