using System;
using System.Web;
using System.Web.Http;
using APIMVCLearning.Models;
using APIMVCLearning.RequestPayload.Authentication;
using APIMVCLearning.Utils;

namespace APIMVCLearning.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApiController
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult  Login(LoginPayload bodyPayload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new User() { email = "taeyzao@gmail.com"};
            var cookie = new HttpCookie("user-token", new JWTServices().generateJWTToken(user));
            cookie.Expires = DateTime.Now.AddDays(2);  
            cookie.Domain = Request.RequestUri.Host;  
            cookie.Path = "/";
            cookie.HttpOnly = true;
            HttpContext.Current.Response.SetCookie(cookie);
            return Json(user);
        }

        [HttpPost]
        [Route("logout")]
        public IHttpActionResult Logout()
        {
            HttpContext.Current.Response.Cookies["user-token"].Expires = DateTime.Now.AddDays(-1);
            return Json(new {message = "logout success"});
        }
    }
}