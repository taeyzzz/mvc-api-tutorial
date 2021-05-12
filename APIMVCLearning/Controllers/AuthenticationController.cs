using System;
using System.Web;
using System.Web.Http;
using APIMVCLearning.Repositories;
using APIMVCLearning.RequestPayload.Authentication;
using APIMVCLearning.Utils;

namespace APIMVCLearning.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApiController
    {
        private UserRepository _userRepository;
        public AuthenticationController()
        {
            _userRepository = new UserRepository();
        }
         
        [HttpPost]
        [Route("login")]
        public IHttpActionResult  Login(LoginPayload bodyPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adminUser = _userRepository.getAdminUser();
            if (bodyPayload.email != adminUser.email)
            {
                return Unauthorized();
            }
            var cookie = new HttpCookie("user-token", new JWTServices().generateJWTToken(adminUser));
            cookie.Expires = DateTime.Now.AddDays(2);  
            cookie.Domain = Request.RequestUri.Host;  
            cookie.Path = "/";
            cookie.HttpOnly = true;
            HttpContext.Current.Response.SetCookie(cookie);
            return Json(adminUser);
        }

        [HttpPost]
        [Route("logout")]
        public IHttpActionResult Logout()
        {
            if (HttpContext.Current.Response.Cookies["user-token"] != null)
            {
                HttpContext.Current.Response.Cookies["user-token"].Expires = DateTime.Now.AddDays(-1);   
            }
            return Json(new {message = "logout success"});
        }
    }
}
