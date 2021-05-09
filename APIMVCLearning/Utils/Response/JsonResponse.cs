using System.Web.Mvc;

namespace APIMVCLearning.Utils.Response
{
    public class JsonResponse: JsonResult
    {
        private const int DEFAULT_STATUS_CODE = 200;
        private readonly int _statusCode = DEFAULT_STATUS_CODE;
        public JsonResponse(object data)
        {
            this.Data = data;
        }
        
        public JsonResponse(int? statusCode, object data)
        {
            if (statusCode != null)
            {
                _statusCode = (int)statusCode;
            }
            this.Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = _statusCode;
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            base.ExecuteResult(context);
        }

    }
}