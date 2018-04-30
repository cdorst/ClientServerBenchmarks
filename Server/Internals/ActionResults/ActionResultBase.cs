using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static Server.Internals.ActionResults.ByteOffsetConstant;

namespace Server.Internals.ActionResults
{
    internal abstract class ActionResultBase : IActionResult
    {
        private readonly byte[] _payload;
        protected readonly int _payloadLength;

        public ActionResultBase(byte[] payload)
        {
            _payload = payload;
            _payloadLength = _payload.Length;
        }

        public Task ExecuteResultAsync(ActionContext context)
            => GetResponse(context)
                .Body
                .WriteAsync(_payload, OffsetZero, _payloadLength);

        protected virtual HttpResponse GetResponse(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.StatusCode = Status200OK;
            response.ContentLength = _payloadLength;
            return response;
        }
    }
}
