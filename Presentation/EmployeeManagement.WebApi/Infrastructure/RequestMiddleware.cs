using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Text;

namespace EmployeeManagement.WebApi.Infrastructure
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestMiddleware> _logger;

        public RequestMiddleware(RequestDelegate next, ILogger<RequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {

                var log = new
                {
                    data = await FormatRequest(httpContext.Request),
                    info = RequestLogInfo
                    .Create
                    .ForContext(httpContext)
                };
                _logger.LogInformation("{@log}", log);

                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var _logTrace = ExceptionLogTrace(ex);
                StringBuilder message = new StringBuilder(ex.Message);
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    message.Append(" -> " + ex.Message);
                }
                _logger.LogError("{@v}", new {LogTrace = _logTrace, ExceptionMessage = message.ToString() });
            }
        }
        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var body = request.Body;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];

            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var bodyAsText = Encoding.UTF8.GetString(buffer);

            request.Body.Seek(0, SeekOrigin.Begin);
            request.Body = body;

            return Encoding.Unicode.GetByteCount(bodyAsText) <= 2048 ? bodyAsText : "Body size is large than 2 Kb";
        }

        string ExceptionLogTrace(Exception Ex)
        {
            try
            {
                var strackTraceFrames = new StackTrace(Ex, true).GetFrames().Select(x => new { method = x.GetMethod(), line = x.GetFileLineNumber() })
                                                                .Where(m => m.method.Module.Assembly == Assembly.GetExecutingAssembly())
                                                                .Select(x => x.method.ReflectedType.Name + "." + x.method.Name + " -> line: " + x.line).ToList();

                return String.Join("; ", strackTraceFrames.ToArray().Reverse());
            }
            catch (Exception ex)
            {

                return "Stack trace is not available! " + ex.Message;
            }

        }
    }
}
