using System.Collections.Generic;
using System.Web.Http;
using APIMVCLearning.Models;


namespace APIMVCLearning.Controllers
{
    [Route("api/users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ListUser()
        {
            var users = new List<User>()
            {
                new User(){ email = "taeyza@gmail.com", birthday = "1993-12-07"},
                new User(){ email = "hello@gmail.com" }
            };
            return Json(users);
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
            return Json(userPayload);
        }

        [HttpPatch]
        public IHttpActionResult UpdateUser(User userPayload, int id)
        {
            return Json(userPayload);
        }

    }
}