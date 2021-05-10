using System.Collections.Generic;
using System.Web.Http;
using APIMVCLearning.Attributes;
using APIMVCLearning.Models;


namespace APIMVCLearning.Controllers
{
    [AuthenticationFilter]
    [Route("api/users")]
    public class UsersController : ApiController
    {
        public static List<User> listUser = new List<User>();
        [HttpGet]
        public IHttpActionResult ListUser()
        {
            return Json(listUser);
        }
        
        [HttpGet]
        public IHttpActionResult GetUser(int id)
        {
            return Json(new User() {email = "taeyza@gmail.com", birthday = "1993-12-07"});
        }

        [HttpPost]
        public IHttpActionResult CreateUser(User userPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            listUser.Add(userPayload);
            return Json(userPayload);
        }

        [HttpPatch]
        public IHttpActionResult UpdateUser(User userPayload, int id)
        {
            return Json(userPayload);
        }
    }
}