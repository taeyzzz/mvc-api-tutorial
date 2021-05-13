using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace APIMVCLearning.Attributes
{
    public class ErrorHandlerAttribute : ExceptionFilterAttribute
    {
        private const string UNAUTHORIZED = "Unauthorized";

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            // TODO error handler preparation.
            var response = new HttpResponseMessage();
            switch (actionExecutedContext.Exception.Message)
            {
                case UNAUTHORIZED:
                {
                    response.StatusCode = HttpStatusCode.Unauthorized;
                    break;
                }
                default:
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    break;
                }
            }

            var exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
                exceptionMessage = actionExecutedContext.Exception.Message;
            else
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;

            response.Content = new StringContent(exceptionMessage);

            actionExecutedContext.Response = response;
        }
    }
}