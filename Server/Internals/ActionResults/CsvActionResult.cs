using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Server.Internals.ActionResults.ContentTypeConstants;
using static System.Text.Encoding;

namespace Server.Internals.ActionResults
{
    internal class CsvActionResult : ActionResultBase
    {
        public CsvActionResult(string content) : base(UTF8.GetBytes(content))
        {
        }

        protected override HttpResponse GetResponse(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = Status200OK;
            response.ContentLength = _payloadLength;
            response.ContentType = CSV;
            return response;
        }
    }
}
