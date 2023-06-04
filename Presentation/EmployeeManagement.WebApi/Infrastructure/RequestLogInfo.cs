namespace EmployeeManagement.WebApi.Infrastructure
{
    public class RequestLogInfo
    {
        public string IpAddress { get; set; }

        public string Path { get; set; }

        public string QueryString { get; set; }

        public string UserAgent { get; set; }

        public string Source { get; set; }

        public DateTime LogDate { get; set; } = DateTime.Now;

        public string Username { get; set; }
        public static RequestLogInfo Create => new RequestLogInfo();
        public RequestLogInfo ForContext(HttpContext httpContext)
        {
            Path = httpContext.Request.Path;
            QueryString = httpContext.Request.QueryString.ToString();
            IpAddress = httpContext.Connection.RemoteIpAddress.ToString();
            UserAgent = GetHeaderValue(httpContext, "User-Agent");
            Source = GetHeaderValue(httpContext, "custom-source");

            if (httpContext.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                IpAddress = GetHeaderValue(httpContext, "X-Forwarded-For");
            }

            return this;
        }

        private static string GetHeaderValue(HttpContext httpContext, string key) => httpContext.Request.Headers[key].ToString();
    }
}
