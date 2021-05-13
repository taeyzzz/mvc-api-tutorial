using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using APIMVCLearning.Repositories;
using APIMVCLearning.Utils;

namespace APIMVCLearning.Attributes
{
    public class AuthenticationFilterAttribute: ActionFilterAttribute
    {
        private UserRepository _userRepository;

        public AuthenticationFilterAttribute()
        {
            _userRepository = new UserRepository();
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            CookieHeaderValue cookie = actionContext.Request.Headers.GetCookies("user-token").FirstOrDefault();
            if (cookie == null)
            {
                throw new Exception("Unauthorized");
            }
            else
            {
                var token = cookie["user-token"].Value;
                var email = (string)new JWTServices().verifyJWTToken(token);
                var adminUser = _userRepository.getAdminUser();
                if (email != adminUser.email)
                {
                    throw new Exception("Unauthorized");
                }
                // TODO store current user to context
            }
        }
    }
}