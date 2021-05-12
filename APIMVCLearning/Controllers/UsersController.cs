using System.Collections.Generic;
using System.Web.Http;
using APIMVCLearning.Attributes;
using APIMVCLearning.Models;
using APIMVCLearning.Repositories;


namespace APIMVCLearning.Controllers
{
    [AuthenticationFilter]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        public static UserRepository userRepo = new UserRepository();
        [HttpGet]
        public IHttpActionResult ListUser()
        {
            return Json(userRepo.getAllUsers());
        }
        
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            return Json(userRepo.getUserById(id.ToString()));
        }

        [HttpPost]
        public IHttpActionResult CreateUser(User userPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = userRepo.addUser(userPayload);
            return Json(newUser);
        }

        [HttpPatch]
        public IHttpActionResult UpdateUser(User userPayload, int id)
        {
            return Json(userPayload);
        }
    }
}