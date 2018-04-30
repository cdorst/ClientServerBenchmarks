using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Jil.JSON;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Server.Internals.ActionResults.ContentTypeConstants;
using static Server.Internals.ActionResults.JilOptionsConstants;
using static System.Text.Encoding;

namespace Server.Internals.ActionResults
{
    internal class JsonActionResult : ActionResultBase
    {
        public JsonActionResult(object @object)
            : base(UTF8.GetBytes(Serialize(@object, JilOptions)))
        {
        }

        protected override HttpResponse GetResponse(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = Status200OK;
            response.ContentLength = _payloadLength;
            response.ContentType = JSON;
            return response;
        }
    }
}
