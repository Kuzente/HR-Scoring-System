namespace SamiProje.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request)
        {
            return request.QueryString.HasValue
                ? $"{request.Path}{request.Query}"
                : request.Path.ToString();
        }
    }
}
