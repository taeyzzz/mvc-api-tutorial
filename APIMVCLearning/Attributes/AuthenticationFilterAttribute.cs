using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using APIMVCLearning.Utils;

namespace APIMVCLearning.Attributes
{
    public class AuthenticationFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            CookieHeaderValue cookie = actionContext.Request.Headers.GetCookies("user-token").FirstOrDefault();
            try
            {
                if (cookie == null)
                {
                    throw new Exception("Unauthorized");
                }
                else
                {
                    var token = cookie["user-token"].Value;
                    var email = new JWTServices().verifyJWTToken(token);
                    // TODO store current user to context
                }
            }
            catch (Exception e)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}